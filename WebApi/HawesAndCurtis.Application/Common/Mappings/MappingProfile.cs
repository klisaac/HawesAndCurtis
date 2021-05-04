using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using HawesAndCurtis.Application.Models;
using HawesAndCurtis.Application.Responses;
using HawesAndCurtis.Application.Commands;
using HawesAndCurtis.Core.Entities;
using HawesAndCurtis.Core.Pagination;

namespace HawesAndCurtis.Application.Common.Mappings
{
    // The best implementation of AutoMapper for class libraries - https://stackoverflow.com/questions/26458731/how-to-configure-auto-mapper-in-class-library-project
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateUserMap();
            CreateProductTypeMap();
            CreateProductMap();
            CreateProductRecommendationMap();
        }
        
        private void CreateUserMap()
        {
            CreateMap<CreateUserCommand, User>()
                .ForMember(dest => dest.UserName, map => map.MapFrom(src => src.UserName));

            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.UserId, map => map.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserName, map => map.MapFrom(src => src.UserName)).ReverseMap();
        }
        private void CreateProductTypeMap()
        {
            CreateMap<ProductType, ProductTypeModel>()
                .ForMember(dest => dest.ProductTypeId, map => map.MapFrom(src => src.ProductTypeId))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, map => map.MapFrom(src => src.Description)).ReverseMap();

            CreateMap<ProductType, ProductTypeResponse>()
                .ForMember(dest => dest.ProductTypeId, map => map.MapFrom(src => src.ProductTypeId))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, map => map.MapFrom(src => src.Description)).ReverseMap();

            CreateMap<ProductRecommendation, ProductTypeResponse>()
                .ForMember(dest => dest.ProductTypeId, map => map.MapFrom(src => src.RecommendedProduct.ProductTypeId))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.RecommendedProduct.ProductType.Name))
                .ForMember(dest => dest.Description, map => map.MapFrom(src => src.RecommendedProduct.ProductType.Description));
        }

        private void CreateProductMap()
        {
            CreateMap<ProductSpecification, SpecificationModel>()
                .ForMember(dest => dest.SpecificationId, map => map.MapFrom(src => src.ProductSpecificationId))
                .ForMember(dest => dest.Specification, map => map.MapFrom(src => src.Specification)).ReverseMap();

            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.ProductId, map => map.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Code, map => map.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, map => map.MapFrom(src => src.Description))
                .ForMember(dest => dest.Category, map => map.MapFrom(src => src.ProductType))
                .ForMember(dest => dest.Price, map => map.MapFrom(src => src.Price))
                .ForMember(dest => dest.ImageFile, map => map.MapFrom(src => src.ImageFile))
                .ForMember(dest => dest.Specifications, map => map.MapFrom(src => src.ProductSpecifications)).ReverseMap();

            CreateMap<IPagedList<Product>, IPagedList<ProductResponse>>()
                .ForMember(dest => dest.Items, map => map.MapFrom(src => src.Items))
                .ForMember(dest => dest.PageIndex, map => map.MapFrom(src => src.PageIndex))
                .ForMember(dest => dest.PageSize, map => map.MapFrom(src => src.PageSize))
                .ForMember(dest => dest.TotalCount, map => map.MapFrom(src => src.TotalCount))
                .ForMember(dest => dest.TotalPages, map => map.MapFrom(src => src.TotalPages))
                .ForMember(dest => dest.HasNextPage, map => map.MapFrom(src => src.HasNextPage))
                .ForMember(dest => dest.HasPreviousPage, map => map.MapFrom(src => src.HasPreviousPage));
        }

        private void CreateProductRecommendationMap()
        {

            CreateMap<ProductRecommendation, ProductResponse>()
                .ForMember(dest => dest.ProductId, map => map.MapFrom(src => src.RecommendedProduct.ProductId))
                .ForMember(dest => dest.Code, map => map.MapFrom(src => src.RecommendedProduct.Code))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.RecommendedProduct.Name))
                .ForMember(dest => dest.Description, map => map.MapFrom(src => src.RecommendedProduct.Description))
                .ForMember(dest => dest.Category, map => map.MapFrom(src => src.RecommendedProduct.ProductType))
                .ForMember(dest => dest.Price, map => map.MapFrom(src => src.RecommendedProduct.Price))
                .ForMember(dest => dest.ImageFile, map => map.MapFrom(src => src.RecommendedProduct.ImageFile))
                .ForMember(dest => dest.Specifications, map => map.MapFrom(src => src.RecommendedProduct.ProductSpecifications)).ReverseMap();

            CreateMap<IPagedList<ProductRecommendation>, IPagedList<ProductResponse>>()
                .ForMember(dest => dest.Items, map => map.MapFrom(src => src.Items))
                .ForMember(dest => dest.PageIndex, map => map.MapFrom(src => src.PageIndex))
                .ForMember(dest => dest.PageSize, map => map.MapFrom(src => src.PageSize))
                .ForMember(dest => dest.TotalCount, map => map.MapFrom(src => src.TotalCount))
                .ForMember(dest => dest.TotalPages, map => map.MapFrom(src => src.TotalPages))
                .ForMember(dest => dest.HasNextPage, map => map.MapFrom(src => src.HasNextPage))
                .ForMember(dest => dest.HasPreviousPage, map => map.MapFrom(src => src.HasPreviousPage));
        }
    }
}
