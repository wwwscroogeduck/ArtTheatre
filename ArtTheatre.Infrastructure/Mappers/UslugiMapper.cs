using ArtTheatre.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTheatre.Infrastructure.Mappers
{
    public static class UslugiMapper
    {
        public static UslusgiViewModel Map(UslugiEntity entity)
        {
            var viewModel = new UslusgiViewModel
            {
                id = entity.id,
                name = entity.name,
                cost = entity.cost,

            };
            return viewModel;
        }

        public static List<UslusgiViewModel> Map(List<UslugiEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
        public static UslugiEntity Map(UslusgiViewModel viewModel)
        {
            var entity = new UslugiEntity
            {
                id = viewModel.id,
                name = viewModel.name,
                cost = viewModel.cost,
            };
            return entity;
        }
    }
}
