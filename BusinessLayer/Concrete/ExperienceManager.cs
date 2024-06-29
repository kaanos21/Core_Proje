using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ExperienceManager :IExpreinceService
    {
        IExpreinceDal _expreinceDal;

        public ExperienceManager(IExpreinceDal expreinceDal)
        {
            _expreinceDal = expreinceDal;
        }

        public void TAdd(Expreince t)
        {
            _expreinceDal.Insert(t);
        }

        public void TDelete(Expreince t)
        {
            _expreinceDal.Delete(t);
        }

        public Expreince TGetByID(int id)
        {
            return _expreinceDal.GetByID(id);
        }

        public List<Expreince> TGetList()
        {
            return _expreinceDal.GetList();
        }

        public List<Expreince> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Expreince t)
        {
            _expreinceDal.Update(t);
        }
    }
}
