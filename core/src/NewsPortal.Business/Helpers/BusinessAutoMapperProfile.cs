﻿using AutoMapper;
using NewsPortal.Business.Models;
using NewsPortal.Data.Entities;
using NewsPortal.Data.Models;

namespace NewsPortal.Business.Helpers
{
    public class BusinessAutoMapperProfile : Profile
    {
        public BusinessAutoMapperProfile()
        {
            CreateMap<GetAllArticlesRequest, GetAllArticlesDto>();
            CreateMap<CategoryEntity, Category>()
                .ReverseMap()
                .ForMember(x => x.Articles, opt => opt.Ignore());
            CreateMap<Article, ArticleEntity>().ReverseMap();
        }
    }
}
