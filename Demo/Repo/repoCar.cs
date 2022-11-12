using Demo.Entity;
using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repo
{
    public class repoCar:IrepoCar
    {
        private readonly CarDetailsDbContext _context;

        public repoCar(CarDetailsDbContext context)
        {
            _context = context;
        }

        public CarDetails create(CarDetails details)
        {
            _context.Add(details);
            _context.SaveChanges();
            return details;
        }

        public CarDetails delete(int? id)
        {
            var deleteCar= _context.cardetails
                .FirstOrDefault(m => m.id == id);

            return deleteCar;
        }

        public CarDetails deleteConfirm(int id)
        {
            var confirmDelete= _context.cardetails.Find(id);
            return confirmDelete;
        }

        public CarDetails details(int? id)
        {
            var details= _context.cardetails
                .FirstOrDefault(m => m.id == id);
            return details;
        }

        public CarDetails edit(int? id)
        {
            var editCar= _context.cardetails.Find(id);
            return editCar;
        }

        public CarDetails editConfirm(CarDetails details)
        {
            _context.Update(details);
            _context.SaveChanges();

            return details;
        }

        public List<CarDetails> index()
        {
            var listOfCar = _context.cardetails.ToList();

            return listOfCar;
        }
    }
}
