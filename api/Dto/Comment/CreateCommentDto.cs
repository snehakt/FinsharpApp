using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api.Dto.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5,ErrorMessage="Title must be 5 characters")]
        //[MaxLength(5, ErrorMessage="Title cannot be over 280 characters")]
         public string Title { get; set; } = string.Empty;

         [Required]
        [MinLength(5,ErrorMessage="Content must be 5 characters")]
        //[MaxLength(5, ErrorMessage="Content cannot be over 280 characters")]
        public string Content { get; set; } =string.Empty;
    }
}