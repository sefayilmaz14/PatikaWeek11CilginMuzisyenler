using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatikaWeek11CilginMuzisyenler.Entities;

namespace PatikaWeek11CilginMuzisyenler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrazyMusiciansController : ControllerBase
    {
        static List<CrazyMusiciansEntity> _musicians = new List<CrazyMusiciansEntity>()
        {
           new CrazyMusiciansEntity {Id=1, Name="Ahmet Çalgı", Job="Ünlü Çalgı Çalar", FunFeature="Her zaman yanlış nota çalar, ama çok eğlenceli"},
           new CrazyMusiciansEntity {Id=2, Name="Zeynep Melodi", Job="Popüler Melodi Yazarı", FunFeature="Şarkıları yanlış anlaşılır ama çok popüler"},
           new CrazyMusiciansEntity {Id=3, Name="Cemil Akor", Job="Çılgın Akorist", FunFeature="Akorları sık değiştirir, ama şaşırtıcı derecede yetenekli"},
           new CrazyMusiciansEntity {Id=4, Name="Fatma Nota", Job="Sürpriz Nota Üreticisi", FunFeature="Nota üretirken sürekli sürprizler hazırlar"},
           new CrazyMusiciansEntity {Id=5, Name="Hasan Ritim", Job="Ritim Canavarı", FunFeature="Her ritmi kendi tarzında yapar, hiç uymaz ama komiktir"},
           new CrazyMusiciansEntity {Id=6, Name="Elif Armoni", Job="Armoni Ustası", FunFeature="Armonilerini bazen yanlış çalar, ama çok yaratıcıdır"},
           new CrazyMusiciansEntity {Id=7, Name="Ali Perde", Job="Perde Uygulayıcı", FunFeature="Her perdeyi farklı şekilde çalar, her zaman sürprizlidir"},
           new CrazyMusiciansEntity {Id=8, Name="Ayşe Rezonans", Job="Rezonans Uzmanı", FunFeature="Rezonans konusunda uzman, ama bazen çok gürültü çıkarır"},
           new CrazyMusiciansEntity {Id=9, Name="Murat Ton", Job="Tonlama Meraklısı", FunFeature="Tonlamalarındaki farklılıklar bazen komik, ama oldukça ilginç"},
           new CrazyMusiciansEntity {Id=10, Name="Selin Akor", Job="Akor Sihirbazı", FunFeature="Akorları değiştirdiğinde bazen sihirli bir hava yaratır"},

        };

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            return Ok(_musicians);
        }

        [HttpGet("{id:int:min(1)}")]
        public IActionResult Get(int id)
        {
            var musician = _musicians.FirstOrDefault(x => x.Id == id);

            if (musician == null)
                return NotFound();
            return Ok(musician);

        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string keyword)
        {
            var entity = _musicians.Where(x =>
                                             x.Name.ToLower().Contains(keyword.ToLower()) ||
                                             x.FunFeature.ToLower().Contains(keyword.ToLower()) ||
                                             x.Job.ToLower().Contains(keyword.ToLower())).ToList();


            if (entity.Count == 0)
                return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CrazyMusiciansEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _musicians.Max(x => x.Id) + 1;

            entity.Id = id;

            _musicians.Add(entity);

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPatch("name/{id:int:min(1)}")]

        public IActionResult NameEdit(int id, [FromBody] string newName)
        {
            var entity = _musicians.FirstOrDefault(x => x.Id == id);

            if (entity == null)
                return NotFound();
            entity.Name = newName;
            return Ok(entity);

        }

        [HttpPut("{id}")]

        public IActionResult Edit(int id, [FromBody] CrazyMusiciansEntity entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }

            var musician = _musicians.FirstOrDefault(x => x.Id == id);

            if (musician is null)
                return NotFound();

            musician.Name = entity.Name;
            musician.FunFeature = entity.FunFeature;
            musician.Job = entity.Job;
            return Ok(musician);

        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var entity = _musicians.FirstOrDefault(x => x.Id == id);

            if (entity == null)
                return NotFound();
            entity.IsDeleted = true;
            return Ok(entity);
        }

       
    }
}
