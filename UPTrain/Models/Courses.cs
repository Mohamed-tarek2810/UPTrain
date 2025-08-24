using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UPTrain.Models
{
    public class Courses
    {
        [Key] 
        public int CourseId { get; set; }

        [Required]
        [StringLength(200)]
        public string? Title { get; set; }

        [StringLength(10000)]
        public string? Description { get; set; }

        [Required]
        [StringLength(100)]
        public string? Category { get; set; }

        [Required]
        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }

        [StringLength(500)]
        public string? ImageUrl { get; set; }

        [ForeignKey("CreatedBy")]
        public User Creator { get; set; } = null!;

        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
        public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
        public ICollection<Point> Points { get; set; } = new List<Point>();
    }
}
