using _01_Farmework.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;


namespace ShopManagement.Application.Slide
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IFileUploader _fileUploader;
        public SlideApplication(ISliderRepository sliderRepository,IFileUploader fileUploader)
        {
            _sliderRepository = sliderRepository;
            _fileUploader = fileUploader;
        }
        public OperationResult Create(CreateSlide command)
        {
            var operation = new OperationResult();
            var path = "slides";
            var slideName = _fileUploader.Upload(command.Picture, path);
            var slide = new Domain.SlideAgg.Slide(slideName, command.Title,command.PictureAlt
                ,command.Heading,command.Title,command.Text,command.BtnText,command.Link);
            _sliderRepository.Create(slide);
            _sliderRepository.Save();
            return operation.Succedded();
                
        }

        public OperationResult Edit(EditSlide command)
        {
            var operation = new OperationResult();
            var slide = _sliderRepository.Get(command.id);
            if (slide == null)
                return operation.Faild(ApplicationMessage.RecordNotFound);
            var path = "slides";
            var slideName = _fileUploader.Upload(command.Picture, path);
            slide.Edit(slideName, command.Title, command.PictureAlt
                , command.Heading, command.Title, command.Text, command.BtnText,command.Link);
            _sliderRepository.Save();
            return operation.Succedded();

       
        }

        public EditSlide GetDetails(long id)
        {
            return _sliderRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _sliderRepository.GetList();
        }

        public OperationResult Remove(long id)
        {
            var operatin = new OperationResult();
            var slide = _sliderRepository.Get(id);
            if (slide == null)
                return operatin.Faild(ApplicationMessage.RecordNotFound);
            slide.Remove();
            _sliderRepository.Save();
            return operatin.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operatin = new OperationResult();
            var slide = _sliderRepository.Get(id);
            if (slide == null)
                return operatin.Faild(ApplicationMessage.RecordNotFound);
            slide.Restore();
            _sliderRepository.Save();
            return operatin.Succedded();
        }
    }
}
