﻿using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudosApi.Domain.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductModel>> BuscarProdutos (ProductDataModel productDataModel);
        Task<ProductModel> BuscarProdutosPorId(int id);
        Task<List<ProductModel>> BuscarProdutosPorNome(string name);
        Task<ProductModel> Adicionar(ProductDataModel produto);
    }
}
