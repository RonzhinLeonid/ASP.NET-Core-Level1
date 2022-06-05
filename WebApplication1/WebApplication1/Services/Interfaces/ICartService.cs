using WebApplication1.ViewModels;

namespace WebApplication1.Services.Interfaces
{
	public interface ICartService
	{
        void Add(int Id);

        void Decrement(int Id);

        void Remove(int Id);

        void Clear();

        CartViewModel GetViewModel();
    }
}
