using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models;

namespace Tier2.Data.Network
{
    public interface INetwork
    {
        //string GetAllBookSales();
        Task<IList<BookSale>> GetBookSaleAsync(string username);
        void UpdateBookSale(BookSale sale);
        void DeleteBookSale(int id);
        void CreateBookSale(BookSale bookSale);
        
        //Customer stuff
        void UpdateCustomer(Models.Customer customer);
        void CreateCustomer(Models.Customer customer);
        Task<IList<Models.Customer>> GetCustomerAsync(string username);
        void DeleteCustomer(string username);
        Task<double> GetRatingAsync(string username);
        void RateCustomer(Rating rating);

        // User stuff
        void CreateUser(Models.User user);
        Task<IList<Models.User>> GetUserListAsync(string username);
        Task<Models.User> GetSpecificUserLoginAsync(string username, string password);
        void UpdateUser(Models.User user);
        void DeleteUser(string username);
        
        //Purchase Request
        void CreatePurchaseRequest(IList<PurchaseRequest> purchaseRequests);
        Task<IList<PurchaseRequest>> GetPurchaseRequestAsync(string username);
        Task<IList<PurchaseRequest>> GetPurchaseRequestFromIdAsync(int id);
        void DeletePurchaseRequest(int id);
        void DeletePurchaseRequestFromSaleId(int id);


    }
}