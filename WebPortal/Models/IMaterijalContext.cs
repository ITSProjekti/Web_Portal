﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPortal.Models
{
    public interface IMaterijalContext
    {
        IQueryable<MaterijalModel> materijali { get; }

        int SaveChanges();

        T Add<T>(T entity) where T : class;

        MaterijalModel pronadjiMaterijalPoId(int id);

        MaterijalModel pronadjiMaterijalPoNazivu(string naziv);

        T Delete<T>(T entity) where T : class;

    }
}
