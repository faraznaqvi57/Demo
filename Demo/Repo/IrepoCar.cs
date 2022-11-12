using Demo.Models;

namespace Demo.Repo
{
    public interface IrepoCar
    {
        List<CarDetails> index();
        CarDetails details(int? id);

        CarDetails create(CarDetails details);

        CarDetails edit(int? id);

        CarDetails editConfirm(CarDetails details);
        CarDetails delete(int? id);  
        CarDetails deleteConfirm(int id);



    }
}
