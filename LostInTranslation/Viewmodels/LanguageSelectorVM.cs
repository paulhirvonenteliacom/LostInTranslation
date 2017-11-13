using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LostInTranslation.Viewmodels
{
    public class LanguageSelectorVM
    {
        public string Heading { get; set; }

        [Display(Name="Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phrase")]
        public string Phrase { get; set; }

        public int? SelectedLanguageId { get; set; }

        [Display(Name = "Language")]
        public IEnumerable<SelectListItem> Language { get; set; }

        public string StartMessage { get; set; }

        public int StageInProcess { get; set; }

        public LanguageSelectorVM()
        {
            StartMessage = "The WhisperROBOT is starting";
        }
    }
}