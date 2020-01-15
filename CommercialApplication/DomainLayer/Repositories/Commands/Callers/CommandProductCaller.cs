using CommercialApplication.DomainLayer.Repositories.Commands.ProductCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.Callers
{
    public class CommandProductCaller
    {
        public Dictionary<string, IProductCommand> DictCommands { get; set; }
        public CommandProductCaller()
        {
            DictCommands = new Dictionary<string, IProductCommand>();
            DictCommands.Add("GetAll", new GetAllProductCommand());
            DictCommands.Add("GetAllFruits", new GetAllFruitsCommand());
            DictCommands.Add("GetAllVegetables", new GetAllVegetablesCommand());
            DictCommands.Add("Get", new GetProductCommand());
            DictCommands.Add("GetByName", new GetProductCommandByName());
            DictCommands.Add("InsertProduct", new InsertProductCommand());
            DictCommands.Add("UpdateProduct", new UpdateProductCommand());
            DictCommands.Add("UpdateFruitsUnit", new UpdateFruitsUnitCostCommand());
            DictCommands.Add("UpdateVegetablesUnitCost", new UpdateVegetablesUnitCostCommand());
            DictCommands.Add("UpdateProductState", new UpdateProductStateCommand());
            DictCommands.Add("DeleteProduct", new DeleteProductCommand());
            DictCommands.Add("GetAllProductsFromStorage", new GetAllProductsFromStorageCommand());
            DictCommands.Add("GetProductFromAllStorages", new GetProductFromAllStoragesCommand());
            DictCommands.Add("InsertProductInStorage", new InsertProductInStorageCommand());
            DictCommands.Add("DeleteProductFromStorage", new DeleteProductFromStorageCommand());
            DictCommands.Add("IsProductExist", new IsProductExistCommand());
        }
    }
}
