using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        [MinLength(5,ErrorMessage ="Proje Adı en az 5 karakter olmalıdır.")]
        [MaxLength(50,ErrorMessage ="Proje Adı en fazla 50 karakter olmalıdır.")]
        [Required(ErrorMessage = "Proje Adı boş geçilemez.")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Proje açıklaması boş geçilemez.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Proje Görsel Url boş geçilemez.")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Github Url boş geçilemez.")]
        public string GithubUrl { get; set; }
      
        [Required(ErrorMessage = "Kategori boş geçilemez.")]
        public int CategoryId { get; set; }
        //navigation property
        public Category? Category { get; set; }
    }
}
