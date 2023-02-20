using DotStarkProjectData.Context;
using DotStarkProjectData.Model;
using static DotStarkProjectData.Model.CommonModel;

namespace DotStarkProjectBLL.Interface
{
    public interface IProduct
    {
        string GetTime();
        CommonModel.ApplicationTransaction SaveProduct(Products model);
        (List<ProductModel>, ApplicationTransaction) GetProductList();
        (List<JsonHolderPostsModel>, ApplicationTransaction) GetPostsList();
    }
}
