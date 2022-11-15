
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravisBrownBlog.Models
{
    public class BlogPost
    {
        // Primary Key
        public int Id { get; set; }

        [Required]
        public string? CreatorId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and max {1} character long.", MinimumLength = 2)]
        public string? Title { get; set; }

        [Required]
        public string? Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? LastUpdated { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        public string? Slug { get; set; }

        public string? Abstract { get; set; }

        public bool IsDeleted { get; set; }


        [DisplayName("Published")]
        public bool IsPublished { get; set; }



        public byte[]? ImageData { get; set; }

        public string? ImageType { get; set; }

        [NotMapped]
        public IFormFile? BlogPostImage { get; set; }

        // Naviagtion Propeties
        public virtual Category? Category { get; set; } 

        
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();

        public virtual BlogUser? Creator { get; set; }
    }
}
