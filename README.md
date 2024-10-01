# PatikaWeek11CilginMuzisyenler

Proje, eğlenceli müzisyenler ile ilgili bir RESTful API içerir. API, çılgın müzisyenler hakkında bilgi verir, yeni müzisyenler ekler ve mevcut müzisyenlerin isimlerini güncelleyebilir.

## Proje İçeriği

Bu proje, .NET Core tabanlı bir Web API uygulamasıdır. Proje ile çılgın müzisyenlerin özelliklerini yönetebilir ve onlara ait verilere ulaşabilirsiniz.

### Özellikler:
- **Tüm müzisyenleri listele**: API, veritabanında bulunan tüm müzisyenleri JSON formatında sunar.
- **Tek bir müzisyeni getir**: Belirli bir müzisyenin bilgilerini ID'si ile alabilirsiniz.
- **Yeni müzisyen ekle**: API aracılığıyla yeni müzisyen ekleyebilirsiniz.
- **Müzisyen ismini güncelle (PATCH)**: Belirli bir müzisyenin ismini güncelleyebilirsiniz.

## Kurulum

Projeyi bilgisayarınızda çalıştırmak için aşağıdaki adımları izleyin:

1. **Depoyu klonlayın**:
    ```bash
    git clone https://github.com/kullanici-adi/PatikaWeek11CilginMuzisyenler.git
    ```

2. **Gerekli bağımlılıkları yükleyin**:
   Proje klasörüne gidin ve NuGet paketlerini yükleyin:
    ```bash
    cd PatikaWeek11CilginMuzisyenler
    dotnet restore
    ```

3. **Projeyi çalıştırın**:
    ```bash
    dotnet run
    ```

## Kullanım

Projeyi çalıştırdıktan sonra aşağıdaki API uç noktalarını kullanabilirsiniz:

- **GET** `/api/crazymusicians`: Tüm müzisyenleri listeler.
- **GET** `/api/crazymusicians/{id}`: Belirli bir müzisyeni ID ile getirir.
- **POST** `/api/crazymusicians`: Yeni bir müzisyen ekler.
    - Gövde (body) örneği:
    ```json
    {
        "Name": "Yeni Müzisyen",
        "Job": "Çılgın Müzisyen",
        "FunFeature": "Her zaman komik şarkılar çalar"
    }
    ```
- **PATCH** `/api/crazymusicians/{id}`: Belirli bir müzisyenin ismini günceller.
    - Gövde (body) örneği:
    ```json
    "Yeni Müzisyen İsmi"
    ```

