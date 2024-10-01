using System.ComponentModel.DataAnnotations;

namespace PatikaWeek11CilginMuzisyenler.Entities
{
    public class CrazyMusiciansEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Sanatçı Adı Gereklidir" )]
        public string Name { get; set; }
        [Required(ErrorMessage = "Sanatçı Mesleği Gereklidir")]
        public string Job { get; set; }
        [Required(ErrorMessage = "Sanatçı Eğlenceli Özelliği Gereklidir")]
        public string FunFeature { get; set; }
        public bool IsDeleted { get; set; }

    }
}
