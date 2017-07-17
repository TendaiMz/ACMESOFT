using ACME_DOMAIN.CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ACME_REPOSITORY
{
    /// <summary>
    /// Provides functionality to perform Create,Read,Update and Delete operations based on the specified entity using the Entityframework
    /// </summary>
    /// <typeparam name="TEntity">The entity to use for perfoming CRUD operations</typeparam>
    public interface IEmployeeRepository
    {
        void Update(EmployeeDTO entity);

        void Insert(EmployeeDTO entity);

        EmployeeDTO Find(int id);

        void Delete(int id);

        IEnumerable<EmployeeDTO> All();

    }
}



