using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BProduct
    {
        private DProduct dProduct = null;

        public List<Product> GetProductsActivate()
        {
            List<Product> products = null;
            try
            {
                dProduct = new DProduct();
                products = dProduct.listProductsActivate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dProduct = null;
            }
            return products;
        }

        public List<Product> GetProductsDesactive()
        {
            List<Product> products = null;
            try
            {
                dProduct = new DProduct();
                products = dProduct.listProductsDesactivate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dProduct = null;
            }
            return products;
        }

        public bool InsertProduct(Product product)
        {
            bool result = true;
            try
            {
                dProduct = new DProduct();
                dProduct.insertProduct(product);
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            finally
            {
                dProduct = null;
            }
            return result;
        }

        public bool UpdateProduct(Product product)
        {
            bool result = true;
            try
            {
                dProduct = new DProduct();
                dProduct.updateProduct(product);
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            finally
            {
                dProduct = null;
            }
            return result;
        }

        public bool UpdateProductDesactivate(int id)
        {
            bool result = true;
            try
            {
                dProduct = new DProduct();
                dProduct.desactivateProduct(new Product
                {
                    ProductID = id
                });
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            finally
            {
                dProduct = null;
            }
            return result;
        }

        public bool UpdateProductActivate(int id)
        {
            bool result = true;
            try
            {
                dProduct = new DProduct();
                dProduct.activateProduct(new Product
                {
                    ProductID = id
                });
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            finally
            {
                dProduct = null;
            }
            return result;
        }

        public bool DeleteProduc(int id)
        {
            bool result = true;
            try
            {
                dProduct = new DProduct();
                dProduct.deleteProduct(new Product
                {
                    ProductID = id
                });
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            finally
            {
                dProduct = null;
            }
            return result;
        }
    }
}
