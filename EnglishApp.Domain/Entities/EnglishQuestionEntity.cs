using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishApp.Domain.Entities;

public sealed class EnglishQuestionEntity(int id,
                                          int englishTextId,
                                          string questionText,
                                          string answer,
                                          DateTime createdAt,
                                          DateTime updatedAt)
{
    public int Id = id;
    public int EnglishTextId = englishTextId;
    public string QuestionText = questionText;
    public string Answer = answer;
    public DateTime CreatedAt = createdAt;
    public DateTime UpdatedAt = updatedAt;
}
