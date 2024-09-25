using Business.Abstract;
using Business.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TestimonialManager(ITestimonialDal testimonialDal) : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal = testimonialDal;
        public IResult Add(Testimonial testimonial)
        {
            _testimonialDal.Add(testimonial);
            return new SuccessResult("Testimonial method added");
        }

        public IResult Delete(int id)
        {
            var result = _testimonialDal.Get(t => t.Id == id);
            if (result != null)
            {
                result.IsDelete = true;
                _testimonialDal.Delete(result);

                return new SuccessResult("Testimonial deleted");
            }
            return new ErrorResult("Testimonial not found");
        }

        public IDataResult<List<Testimonial>> GetAll()
        {
            var result = _testimonialDal.GetAll(t=>t.IsDelete == false);
            if (result.Count > 0)
                return new SuccessDataResult<List<Testimonial>>(result, "Testimonials loaded");
            return new ErrorDataResult<List<Testimonial>>(result, "Testimonials not found");
        }

        public IResult Update(Testimonial testimonial)
        {
            var result = _testimonialDal.Get(t => t.Id == testimonial.Id);
            if (result != null)
            {
                _testimonialDal.Update(testimonial);
                return new SuccessResult("Testimonial updated");
            }
            return new ErrorResult("Testimonial not found");
        }
    }
}
