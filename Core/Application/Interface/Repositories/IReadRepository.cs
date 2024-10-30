using Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Repositories;

public interface IReadRepository<T> where T : class, IEntityBase, new()
{
    #region Bütün uyğun olan elementləri asinxron şəkildə qaytarır
    Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, // Şərtləri müəyyənləşdirən bir lambda ifadəsidir. Əgər null olsa, bütün elementlər qaytarılacaq.
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,// Məlumat bazasından əlavə əlaqəli məlumatları daxil etməyə imkan verir.
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,// Qaytarılan nəticələri müəyyən bir qaydada sıralayır.
        bool enableTracing = false);// ORM üçün izləmə rejimini aktivləşdirir, nəticədə entity dəyişiklikləri izlənilir.
    #endregion

    #region Səhifələnmə ilə asinxron şəkildə elementlər qaytarır
    Task<IList<T>> GetAllAsyncByPaging(Expression<Func<T, bool>>? predicate = null,// Şərtləri müəyyənləşdirən bir lambda ifadəsidir. Əgər null olsa, bütün elementlər qaytarılacaq.
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,// Məlumat bazasından əlavə əlaqəli məlumatları daxil etməyə imkan verir.
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,// Qaytarılan nəticələri müəyyən bir qaydada sıralayır.
        bool enableTracing = false,// ORM üçün izləmə rejimini aktivləşdirir, nəticədə entity dəyişiklikləri izlənilir.
        int currentPage = 1,// Hal-hazırda göstərilən səhifə nömrəsini təyin edir.
        int pageSize = 3);// Hər səhifədə göstəriləcək elementlərin sayını təyin edir.
    #endregion


    #region Tək bir elementi asinxron şəkildə qaytarır
    Task<T> GetAsync(Expression<Func<T, bool>> predicate,// Seçilmiş şərtlərə uyğun olaraq tək bir element qaytarır.
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,// Məlumat bazasından əlavə əlaqəli məlumatları daxil etməyə imkan verir.
        bool enableTracing = false);// ORM üçün izləmə rejimini aktivləşdirir, nəticədə entity dəyişiklikləri izlənilir.
    #endregion

    #region  Məlumat bazasında verilən şərtə uyğun elementləri qaytarır
    IQueryable<T> Find(Expression<Func<T, bool>> predicate,// Şərtləri müəyyənləşdirən bir lambda ifadəsidir, tapılan elementlər IQueryable qaytarılır.
        bool enableTracking = false);// enableTracking izləmə rejimini aktivləşdirir.
    #endregion

    #region  Seçilmiş şərtə əsasən elementlərin sayını qaytarır
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate);// Şərtləri müəyyənləşdirən bir lambda ifadəsidir. Şərtə uyğun olan elementlərin sayını asinxron qaytarır.
    #endregion


}
