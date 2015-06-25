using KuasCore.Models;
using KuasCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace KuasWebApp.Controllers
{
    public class GoodsController : ApiController
    {

        public IGoodsService GoodsService { get; set; }

        [HttpPost]
        public Goods AddGoods(Goods goods)
        {
            CheckGoodsIsNotNullThrowException(goods);

            try
            {
                return GoodsService.AddGoods(goods);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public Goods UpdateGoods(Goods goods)
        {
            CheckGoodsIsNullThrowException(goods);

            try
            {
                GoodsService.UpdateGoods(goods);
                return GoodsService.GetGoodsByName(goods.name);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public void DeleteGoods(Goods goods)
        {
            try
            {
                GoodsService.DeleteGoods(goods);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<Goods> GetAllGoods()
        {
            return GoodsService.GetAllGoods();
        }

        [HttpGet]
        public Goods GetGoodsById(string id)
        {
            var goods = GoodsService.GetGoodsById(id);

            if (goods == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return goods;
        }

        [HttpGet]
        [ActionName("Name")]
        public Goods GetGoodsByName(string input)
        {
            var goods = GoodsService.GetGoodsByName(input);

            if (goods == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return goods;
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果不存在則拋出錯誤.
        /// </summary>
        /// <param name="course">
        ///     課程資料.
        /// </param>
        private void CheckGoodsIsNullThrowException(Goods goods)
        {
            Goods dbGoods = GoodsService.GetGoodsById(goods.id);

            if (dbGoods == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果存在則拋出錯誤.
        /// </summary>
        /// <param name="course">
        ///     課程資料.
        /// </param>
        private void CheckGoodsIsNotNullThrowException(Goods goods)
        {
            Goods dbGoods = GoodsService.GetGoodsById(goods.id);

            if (dbGoods != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }
    }
}