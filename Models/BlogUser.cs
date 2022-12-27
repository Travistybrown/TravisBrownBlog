using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravisBrownBlog.Models
{
    //Liskov substituion Principle the "L" in solid that states that every class or derived class should be sutible for there base or parents class. Meaning that
    //I should be able to enterchange those classes and have my code run properly examples of this is my inheritence of the indentity user.
    public class BlogUser : IdentityUser 
    {
       

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and max {1} character long.", MinimumLength = 2)]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and max {1} character long.", MinimumLength = 2)]
        public string? LastName { get; set; }

        [NotMapped]
        public string? FullName { get { return $"{FirstName} {LastName}"; } }


        public byte[]? ImageData { get; set; }

        public string? ImageType { get; set; }

        [NotMapped]
        public IFormFile? BlogUserImage { get; set; }

        // Navigation Propeties
        public virtual ICollection<BlogPost> BlogPosts { get; set; } = new HashSet<BlogPost>();

        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();

        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();


    }
}
