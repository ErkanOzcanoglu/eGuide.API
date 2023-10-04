using AutoMapper;
using eGuide.Data.Dto.OutComing.Station;
using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Common.Mappers {
    public class CommentMapper  : Profile{
        public CommentMapper() {
            CreateMap<Comment, CommentDto>().ReverseMap();
        }
    }
}
