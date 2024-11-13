using AluguelCarrosAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AluguelCarrosAPI.Controllers
{
    [Route("api/carros")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private static List<Carro> carros = new List<Carro>();

        [HttpPost]
        public ActionResult<List<Carro>> AddCarro (Carro newCar)
        {
            carros.Add(newCar);
            return Ok(carros);
        }

        [HttpGet]
        public ActionResult<List<Carro>> GetCarros ()
        {
            var carsAvailable = carros.Where(x => !x.Alugado).ToList();

            if (carsAvailable.Count == 0) return NotFound("Nenhum carro cadastrado.");

            return Ok(carsAvailable);
        }

        [HttpPost("alugar/{id}")]
        public ActionResult AlugarCarroById (int id)
        {
            var findCar = carros.Find(x => x.Id == id);

            if (findCar is null) return NotFound("Carro não existe.");

            if (findCar.Alugado == true) NotFound("Carro não disponivel para aluguel.");

            findCar.Alugado = true;

            return Ok($"{findCar.Modelo} alugado com sucesso!");
        }

        [HttpPost("alugar/modelo/{modelo}")]
        public ActionResult AlugarCarroByModel(string modelo)
        {
            var findCarModel = carros.Find(x => x.Modelo == modelo);

            if (findCarModel is null) return NotFound("Carro encontrado.");

            if (findCarModel.Alugado == true) NotFound("Este carro já está alugado.");

            findCarModel.Alugado = true;

            return Ok($"{findCarModel.Modelo} ano {findCarModel.Ano} foi alugado com sucesso!");
        }

        [HttpGet("{id}")]
        public ActionResult GetCarroById (int id)
        {
            var viewCar = carros.Find(x => x.Id == id);

            if (viewCar is null) return NotFound("Carro não encontrado.");

            return Ok(viewCar);
        }

        [HttpPut("devolução/{id}")]
        public ActionResult UpdateCarStatusById (int id)
        {
            var car = carros.Find (x => x.Id == id);

            if (car is null) return NotFound("Carro não encontrado.");

            if (car.Alugado == false) return NotFound("Não foi possivel fazer a devolução pois o carro solicitado não esta alugado.");

            car.Alugado = false;

            return Ok($"{car.Modelo} foi devolvido com sucesso. Volte sempre!");
        }

        [HttpPut("devolução/modelo/{modelo}")]
        public ActionResult UpdateCarStatusByModel(string modelo)
        {
            var carModel = carros.Find(x => x.Modelo == modelo);

            if (carModel is null) return NotFound("Carro não encontrado.");

            if (carModel.Alugado == false) return NotFound("Não foi possivel fazer a devolução pois o carro solicitado não esta alugado.");

            carModel.Alugado = false;

            return Ok($"{carModel.Modelo} foi devolvido com sucesso. Volte sempre!");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCar(int id)
        {
            var deleteCar = carros.Find(x  => x.Id == id);

            if (deleteCar is null) return NotFound("Carro não encontrado.");

            carros.Remove(deleteCar);

            return Ok($"{deleteCar.Modelo} deletado com sucesso!");
        }
    }
}
