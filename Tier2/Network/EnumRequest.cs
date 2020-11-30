using System.Text.Json.Serialization;

namespace Tier2.Network
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumRequest
    {
        // Creating new objects in database
        CreateBookSaleNoID,
        CreateUser,
        CreateCustomer,
        
        // Getting from database
        GetBookSale,
        GetAllBookSales,
        GetUser,
        GetCustomer,
        GetCard,
        
        // Selling Book
        SellBook,
        
        // Deleting objects from database
        DeleteSale,
        DeleteUser,
        DeleteCard,
        
        // Rate user
        RateUser,

        // Prototype
        recieveProofOfConcept,
        sendProofOfConcept
    }
}