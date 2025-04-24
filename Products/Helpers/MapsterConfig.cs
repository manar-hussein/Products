using Mapster;
using Products.Models;
using Products.ViewModels.Product;
using System.Reflection;

namespace Products.Helpers
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<CreateProductViewModel, Product>.NewConfig()
            .Map(dest => dest.Name, src => src.ProductName)
            .Map(dest => dest.Ram, src => src.RAM)
            .Map(dest => dest.Os, src => src.OperatingSystem)
            .Map(dest => dest.Colors, src => src.AvailableColors)
            .Map(dest => dest.Storage, src => src.StorageOptions);

            TypeAdapterConfig<Product, ProductViewModel>.NewConfig()
            .Map(dest => dest.Images, src => src.Images.Select(i => i.ImagePath));


            TypeAdapterConfig<UpdateProductViewModel, Product>.NewConfig()
            .Map(dest => dest.Name, src => src.ProductName)
            .Map(dest => dest.Ram, src => src.RAM)
            .Map(dest => dest.Os, src => src.OperatingSystem)
            .Map(dest => dest.Colors, src => src.AvailableColors)
            .Map(dest => dest.Storage, src => src.StorageOptions)
            .Map(dest => dest.HeaderImage, src => src.HeaderImage);
            TypeAdapterConfig<Product, UpdateProductViewModel>.NewConfig()
             .Map(dest => dest.ProductName, src => src.Name)
             .Map(dest => dest.RAM, src => src.Ram)
             .Map(dest => dest.OperatingSystem, src => src.Os)
             .Map(dest => dest.AvailableColors, src => src.Colors)
             .Map(dest => dest.StorageOptions, src => src.Storage)
             .Map(dest => dest.HeaderImage, src => src.HeaderImage);
            TypeAdapterConfig<BuyerDetails, ProductBuyer>.NewConfig()
                .MapWith(src => new ProductBuyer
                {
                    Address = new Address
                    {
                        City = src.City,
                        Country = src.Country,
                        Street = src.Street,
                        ZIPCode = src.ZIPCode
                    },
                    BankCard = new BankCard
                    {
                        CardNumber = src.CardNumber,
                        CVV = src.CVV,
                        ExpiryDate = src.ExpiryDate,
                        NameonCard = src.NameonCard
                    },
                    PaymentMethod = src.PaymentMethod,
                    ProductId = src.ProductId,
                    Quantity = src.Quantity
                });
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
