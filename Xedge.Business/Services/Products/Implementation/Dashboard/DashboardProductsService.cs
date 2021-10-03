using AutoMapper;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Products.Interfaces.Dashboard;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Products;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Manage_Files;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Xedge.Business.Services.Products.Implementation.Dashboard
{
    public class DashboardProductsService : IDashboardProductsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardProductsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateProductAsync(AddProductViewModel addProductViewModel)
        {
            var createState = new CreateState();
            var product = _mapper.Map<AddProductViewModel, Product>(addProductViewModel);
            product.Images = new List<ProductImages>();
            List<SavingFileData> savingFilesData = new List<SavingFileData>();
            Guid key = Guid.NewGuid();
            foreach (var photo in addProductViewModel.Photos)
            {
                string path = "/Uploads/Products/" + key + photo.FileName;
                product.Images.Add(new ProductImages { Path = path });
                var imageData = new SavingFileData()
                {
                    File = photo,
                    fileName = Path.GetFileName(path),
                    folderName = "Products",
                    fileExtention = string.Empty
                };
                savingFilesData.Add(imageData);
            }
            await _unitOfWork.ProductsRepository.CreateAsync(product);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                await _unitOfWork.SystemFilesRepository.SaveFilesAsync(savingFilesData);
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create Product");
            return createState;
        }

        public async Task<ActionState> DeleteProductAsync(int id)
        {
            var actionState = new ActionState();
            var product = await _unitOfWork.ProductsRepository.FindElementAsync(product => product.Id == id, nameof(Product.Images));
            if (product == null)
            {
                actionState.ErrorMessages.Add("Can Not Find Product !");
                return actionState;
            }
            var images = product.Images.Select(image => image.Path);
            _unitOfWork.ProductsRepository.Delete(product);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                foreach (var imagePath in images)
                {
                    var imagedate = new FileBaseData()
                    {
                        fileName = Path.GetFileName(imagePath),
                        folderName = "Products",
                        fileExtention = string.Empty
                    };
                    await _unitOfWork.SystemFilesRepository.DeleteFileAsync(imagedate);
                }
                
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete Product");
            return actionState;
        }

        public async Task<ActionState> EditProductAsync(EditProductViewModel editProductViewModel)
        {
            var actionState = new ActionState();
            var product = _mapper.Map<EditProductViewModel, Product>(editProductViewModel);
            product.Images = new List<ProductImages>();
            List<SavingFileData> savingFilesData = new List<SavingFileData>();
            Guid key = Guid.NewGuid();
            if(editProductViewModel.Photos != null)
            {
                foreach (var photo in editProductViewModel.Photos)
                {
                    string path = "/Uploads/Products/" + key + photo.FileName;
                    product.Images.Add(new ProductImages { Path = path });
                    var imageData = new SavingFileData()
                    {
                        File = photo,
                        fileName = Path.GetFileName(path),
                        folderName = "Products",
                        fileExtention = string.Empty
                    };
                    savingFilesData.Add(imageData);
                }
            }
            
            _unitOfWork.ProductsRepository.Update(product);           
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                await _unitOfWork.SystemFilesRepository.SaveFilesAsync(savingFilesData);
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit Product");
            return actionState;
        }

        public async Task<ProductViewModel> GetProductDetailsAsync(int Id)
        {
            var product = await _unitOfWork.ProductsRepository.FindElementAsync(product => product.Id == Id,
                string.Format("{0},{1},{2},{3},{4}", nameof(Product.SubCategory)
                , nameof(Product.Offer),
                nameof(Product.Market), nameof(Product.Brand), nameof(Product.Images)));

            var productViewModel = _mapper.Map<Product, ProductViewModel>(product);

            return productViewModel;
        }

        public async Task<PagedResult<ListingProductViewModel>> GetDashboardProductsAsync(PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository.GetElementsWithOrderAsync(Product => true,
                       pagingParameters, Product => Product.Id, OrderingType.Descending,
                       string.Format("{0},{1}", nameof(Product.SubCategory), nameof(Product.Brand)));

            var productsViewModel = products.ToMappedPagedResult<Product, ListingProductViewModel>(_mapper);

            return productsViewModel;
        }

        public async Task<ActionState> DeleteProductImageAsync(int productId, string path)
        {
            var actionState = new ActionState();
            var productImage = await _unitOfWork.ProductImagesRepository.FindElementAsync(image => image.Product_Id == productId && image.Path == path);
            _unitOfWork.ProductImagesRepository.Delete(productImage);
            var result = await _unitOfWork.SaveAsync() > 0;
            if(result)
            {
                actionState.ExcuteSuccessfully = true;
                var imagedate = new FileBaseData()
                {
                    fileName = Path.GetFileName(path),
                    folderName = "Products",
                    fileExtention = ""
                };
                await _unitOfWork.SystemFilesRepository.DeleteFileAsync(imagedate);

                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete Product Image");
            return actionState;
        }
    }
}
