♥timeoutstep = 100
♥url = ‴https://translate.google.com/?hl=en&tab=wT#‴
ie.open url ♥url
keyboard ⋘WIN+UP⋙
➜screensearch
timeout.reset value 99999999
file.exists filename ‴♥appdata\Bitoreq AB\LostInTranslation\File.txt‴ timeout 99999999 errorjump ➜screensearch
delay milliseconds 100
file.delete filename ‴♥appdata\Bitoreq AB\LostInTranslation\File.txt‴

window title ‴✱Lost In Translation✱‴
ie.attach phrase ‴Translation‴

ie.getattribute name ‴value‴ search ‴SelectedLanguageId‴ by ‴Id‴ result selectedLanguages
ie.getattribute name ‴value‴ search ‴Phrase‴ result phrase
clipboard text ♥phrase
ie.getattribute name ‴value‴ search ‴Email‴ result email

➜opentranslate
delay 1
window title ‴✱Google✱‴ errorjump ➤startbrowser
ie.attach ‴Google Translate‴

keyboard ‴ ‴⋘CTRL+A BS⋙

jump ➤newlanguage languageUrls ‴en/la/‴❚‴la/jw/‴❚‴jw/gd/‴❚‴gd/kn/‴❚‴kn/ur/‴❚‴ur/en/‴ languages ‴Latin‴❚‴Javanese‴❚‴Scots Gaelic‴❚‴Kannada‴❚‴Urdu‴❚‴Result‴ if ⊂♥selectedLanguages == "1"⊃ 
jump ➤newlanguage languageUrls ‴en/iw/‴❚‴iw/ny/‴❚‴ny/gu/‴❚‴gu/hi‴❚‴hi/mi/‴❚‴mi/en/‴ languages ‴Hebrew‴❚‴Chichewa‴❚‴Gujarati‴❚‴Hindi‴❚‴Maori‴❚‴Result‴ if ⊂♥selectedLanguages == "2"⊃ 
jump ➤newlanguage languageUrls ‴en/pl/‴❚‴pl/hmn/‴❚‴hmn/xh/‴❚‴xh/ps/‴❚‴ps/is‴❚‴is/en‴ languages ‴Polish‴❚‴Hmong‴❚‴Xhosa‴❚‴Pashto‴❚‴Icelandic‴❚‴Result‴ if ⊂♥selectedLanguages == "3"⊃
jump ➤newlanguage languageUrls ‴en/sw/‴❚‴sw/ig/‴❚‴ig/fy/‴❚‴fy/tg‴❚‴tg/sd/‴❚‴sd/en/‴ languages ‴Swahili‴❚‴Igbo‴❚‴Frisian‴❚‴Tajik‴❚‴Sindhi‴❚‴Result‴ if ⊂♥selectedLanguages == "4"⊃
jump ➤newlanguage languageUrls ‴en/mr/‴❚‴mr/ky/‴❚‴ky/ta/‴❚‴ta/eo/‴❚‴eo/da/‴❚‴da/en/‴ languages ‴Marathi‴❚‴Kyrgyz‴❚‴Tamil‴❚‴Esperanto‴❚‴Danish‴❚‴Result‴ if ⊂♥selectedLanguages == "5"⊃
jump  ➜screensearch

procedure ➤newlanguage languageUrls ‴one‴❚‴two‴❚‴three‴❚‴four‴❚‴five‴❚‴six‴ languages ‴one‴❚‴two‴❚‴three‴❚‴four‴❚‴five‴❚‴six‴
♥iteration = 1
♥finalphrase = ‴one‴❚‴two‴❚‴three‴❚‴four‴❚‴five‴❚‴six‴
➜languageloop
➜seturl
ie.seturl url ♥url+♥languageUrls⟦♥iteration⟧
keyboard ⋘CTRL+V⋙ 

delay seconds 2

ie.click ‴gt-swap‴
keyboard ‴ ‴⋘CTRL+A⋙⋘CTRL+C⋙⋘RIGHT⋙
♥finalphrase⟦♥iteration⟧ = ♥clipboard

♥iteration = ♥iteration + 1
jump ➜languageloop if ⊂♥iteration < 7⊃

window title ‴✱Lost In Translation✱‴
ie.attach phrase ‴Translation‴
ie.setattribute name ‴innerHTML‴ value ♥finalphrase⟦6⟧ search ‴result‴
ie.runscript script ‴$(result).css("visibility", "visible")‴

♥iteration = 1
♥emailbody = ⊂"Starting phrase:\t" + ♥phrase + "\n\n"⊃
➜emailconstruction

♥emailbody = ⊂♥emailbody + ♥languages⟦♥iteration⟧ + ":\t" + ♥finalphrase⟦♥iteration⟧ + "\n"⊃

♥iteration = ♥iteration + 1
jump ➜emailconstruction if ⊂♥iteration < 6⊃

♥emailbody = ⊂♥emailbody + "\n" + ♥languages⟦♥iteration⟧ + ":\t" + ♥finalphrase⟦♥iteration⟧⊃

mail.smtp login ‴ourrobotdemo@gmail.com‴ password ‴DemoDagen‴ from ‴ourrobotdemo@gmail.com‴ to ♥email subject ‴Robot results‴ body ⊂♥emailbody⊃ errorjump ➜emaildone

➜emaildone

end

procedure ➤startbrowser
ie.open url ♥url
jump ➜opentranslate
end
