using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRDataAccessLayer
{
    public interface IDAL
    {
        //Transaction Management
        bool IsInTransaction { get; }
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();

        //Concurrency Management
        bool IsDirty { get; }

        //Connection Management
        void OpenConnection();
        void CloseConnection();

        //RUD Methods
        void Save(object item);
        void Update(object item);
        void Delete(object key);

        //Query Management
        IList<T> GetAll<T>() where T : class;
        IList<T> LazyLoad<T>() where T : class;
        IList<T> LazyLoadCriteria<T>(Query query) where T : class;
        IList<T> GetByCriteria<T>(Query query) where T : class;
        IList<T> GetByRegion<T>(string key) where T : class;

        T GetByID<T>(object key) where T : class;
        T GetByDescription<T>(object key) where T : class;
        T LazyLoadByStaffID<T>(object key) where T : class;
        T LazyLoadUnconfirmedByStaffID<T>(object key) where T : class;
        T GetByPhoneNumber<T>(object key) where T : class;

        T ShowImageByStaffID<T>(object key) where T : class;
        T ShowImage<T>() where T : class;
        T GetByOtherID<T>(object key,object key2) where T : class;      
        T GetSalaryAmount<T>(object key1, object key2, object key3) where T : class;
    }
}
