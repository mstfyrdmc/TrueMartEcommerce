using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public enum FolderPath
    {
        Product,
        User,
        Category,
        Brand,
        SubCategory,
        SubSubCategory,
        ProductImage
    }
    public class FxFunction
    {
        public static string ImageUpload(HttpPostedFileBase resim, FolderPath folderPath, out bool isCompleted)
        {
            string errorText = null;
            if (resim != null)
            {
                if (resim.ContentLength <= 2097152)
                {
                    if (resim.ContentType.Contains("image"))
                    {
                        //string uploadPath = $"~/Content/uploads/{ folderPath.ToString()}/{Guid.NewGuid().ToString().Replace('-', '_').ToLower()}.{resim.ContentType.Split('/')[1]}";
                        //resim.SaveAs(HttpContext.Current.Server.MapPath(uploadPath));

                        string uploadPath = $"/Content/uploads/{ folderPath.ToString()}/{Guid.NewGuid().ToString().Replace('-', '_').ToLower()}.{resim.ContentType.Split('/')[1]}";
                        resim.SaveAs(HttpContext.Current.Server.MapPath(uploadPath));
                        isCompleted = true;
                        return uploadPath;
                    }
                    else
                    {
                        errorText = "Lütfen sadece resim yükleyiniz";
                    }
                }
                else
                {
                    errorText = "Seçtiğiniz resimin boyutu 2MB'ı geçmemelidir";
                }
            }
            else
            {
                errorText = "Bir resim seçiniz";
            }

            isCompleted = false;
            return errorText;
        }
    }
}