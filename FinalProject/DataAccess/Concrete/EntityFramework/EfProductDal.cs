using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    //Using(IDispossiple pattern iplementtation of C#) - garbagecollection'a blok bitdikden sora meni sil deyir
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthWindContext>, IProductDal
    {

    }
}
