using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LoginSession.Extensions
{
    public static class SessionHelperExtension
    {
        //Yazma
        public static void SetObject(this ISession session, string key, object value)
        {
            //Buranın bir helper olabilmesi için, genel kapsamlı düşünüp ona göre tasarım gerekir, burada kullandığımız Newtonsoft.Json kütüphanesi, çeşitli web servisler arasında haberleşme sağlasa bile, ortak bir dil(JSON) kullandıkları için bu konuda bana problem çıkarmayacaktır.
            string objString = JsonConvert.SerializeObject(value);
            session.SetString(key, objString);
        }

        //Okuma
        public static T GetObject<T>(this ISession session, string key)where T : class
        {
            //Gönderilen key değeri ile session value'su yakalır (yakalan obje şuan JSON objesi)
            string objString = session.GetString(key);

            if(string.IsNullOrEmpty(objString)) return null;

            //Yakalanan json objesi benim projem içerisinde kullanılıp/kontrol edilebilmesi için, modelime deserialize ediyorum(JSON objesini, kendi class'ıma dönüştürmeye çalışıyorum.
            T objValue = JsonConvert.DeserializeObject<T>(objString);

            return objValue;
        }
    }
}
