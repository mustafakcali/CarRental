using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {


            //DateTime? nullableDateTime = null;
            //if (rental.ReturnDate == nullableDateTime)
            //{
            //    return new ErrorResult("Araba teslim edilmemiş,kiralanamaz.");
            //}

            //if (rental.ReturnDate == null)
            //{
            //    _rentalDal.Get(r => r.CarId == rental.CarId);
            //    return new ErrorResult(Messages.InvalidProcess);
            //}

            var rentals =_rentalDal.GetAll(r=>r.ReturnDate==null);

            foreach (var rent in rentals)
            {
                if (rent.CarId == rental.CarId)
                {
                    return new ErrorResult(Messages.InvalidProcess);
                }
            }

            _rentalDal.Add(rental);
            return new SuccessResult();

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Update(Rental rental)
        {
            

            var rentals = _rentalDal.Get(r=>r.RentalId == rental.RentalId);

            if (rentals != null)
            {
                rental.RentDate = rentals.RentDate; 
                _rentalDal.Update(rental);
                return new SuccessResult("başarılı");
            }
            

            return new ErrorResult("Invalid Process");

            
        }
    }
}
