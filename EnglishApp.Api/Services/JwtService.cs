using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EnglishApp.Api.Services;

/* 
 * たけのこくんと秘密の図書館（JWTのたとえ話）
 * 
 * ある日…
 * たけのこくんは「秘密の図書館」に入りたくなりました。
 * でも図書館の人はこう言いました：
 * 「誰でも入れちゃダメ！ちゃんと名前とパスワードを見せてね！」
 * 
 * ログイン(または新規登録)すると…
 * たけのこくんが名前とパスワードを見せると、図書館の人がこう言いました：
 * 「よし！じゃあこのトークンカードをあげよう！」
 * 
 * => それが「JWTトークン」です。
 * 
 * トークンカードの中身…
 * - 名前：たけのこくん
 * - 図書館：EnglishApp 図書館
 * - 期限：30分後まで
 * - サイン：特別な暗号で書かれていて、改ざんできない
 * 
 * 次からは…
 * 一度ログインしたら、もうパスワードはいりません。
 * トークンカード（JWT）を見せるだけで、図書館に入れるのです。
 */

public class JwtService
{
    private readonly IConfiguration _configuration;
    private readonly string _jwtSecret;
    private readonly TokenValidationParameters _validationParameters;

    public JwtService(IConfiguration configuration)
    {
        this._configuration = configuration;
        this._jwtSecret = this._configuration["Jwt:Key"]!;

        this._validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwtSecret)),
            ClockSkew = TimeSpan.Zero
        };
    }

    public string GenerateToken(int userId)
    {
        // この図書館だけが知ってる“秘密のトークン”を準備(APIキーのバイト列から生成)する。
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(this._jwtSecret));

        // "どのトークン(APIキーのバイト列から生成したトークン)"で、
        // "どんな押し方("HmacSha256"という作り方)"でトークンを押すか決定する。
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

        // トークンにのせる「情報（しょうこ）」をつくるよ！
        Claim[] claims =
        [
            // このトークンは「だれのものか？」を書いておくよ
            // "sub" は「主な人（しゅじんこう）」って意味なんだ
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),

            // これも「だれのものか？」を書くんだけど、
            // "userId" って名前にしておくと、自分たちのプログラムで使いやすいんだ
            new Claim("userId", userId.ToString()),

            // このトークンに「カード番号」をつけるよ！
            // 同じトークンがまざらないように、毎回ちがう番号をふっておくんだ
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        ];


        // トークンをつくるよ！
        JwtSecurityToken token = new(
            // このトークンは「だれが発行したのか？」を書くところ
            // たとえば「EnglishAppのサーバーだよ」って書いてある感じ
            issuer: this._configuration["Jwt:Issuer"], // appsettings.configから取得

            // このトークンは「だれのためのもの？」を書くところ
            // たとえば「EnglishAppのアプリを使ってる人のためだよ」って意味になるよ
            audience: this._configuration["Jwt:Audience"], // appsettings.configから取得

            // さっき作った「これは〇〇さんのカードです！」っていう情報たちを入れるよ
            claims: claims, // 先ほど生成したトークン情報

            // このカードは「いつまで使えるのか？」の時間を書くよ
            // 今の時間から何分後までって設定してるんだ
            expires: DateTime.UtcNow.AddMinutes(
                Int32.Parse(this._configuration["Jwt:ExpiresInMinutes"]!)
            ),

            // このトークンに「サイン（署名）」をつけるよ！
            // サーバーだけが持ってる秘密のサイン道具で「本物だよ」って印を押すんだ
            signingCredentials: credentials
        );

        // スタンプカード（トークン）を「文字のかたち」にするよ！
        // この文字は、アプリやブラウザでサーバーに送れるようにするためのもの
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public int? ValidateToken(string token)
    {
        JwtSecurityTokenHandler handler = new();

        try
        {
            ClaimsPrincipal principal = handler.ValidateToken(token, this._validationParameters, out SecurityToken validatedToken);

            Claim? userIdClaim = principal.FindFirst(JwtRegisteredClaimNames.Sub)
                              ?? principal.FindFirst("userId")
                              ?? principal.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim != null && Int32.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }

            return null;
        }
        catch
        {
            // トークンが不正または期限切れ
            return null;
        }
    }
}
