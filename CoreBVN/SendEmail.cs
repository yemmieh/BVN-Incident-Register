using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CoreBVN
{
    public class SendEmail
    {
        public SendEmail()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        // public string sendEmail(string mailFrom, string mailTo, string subject, string mailBody)
     //sendEmail(mailTo, incidentInput.AccountDetials.Firstname, incidentInput.AccountDetials.LastName, incidentInput.AccountDetials.AccountName, incidentInput.AccountDetials.BVN, incidentInput.Irregularity, incidentInput.Comment, incidentInput.RequesterDetails.Branch, incidentInput.RequesterDetails.StaffName);

        public string sendEmail(string mailTo, string FirstName, string LastName, string AccountName, string BVN, string Irregularity, string Comment, string Branch,string StaffName)
        {

            string smtpClient = "";
            string smtpClientUsername = "";
            string smtpClientPassword = "";
            string mailFrom = "";
            string urLString = "";
          
            smtpClient = ConfigurationManager.AppSettings["smtpClient"].ToString();
            smtpClientUsername = ConfigurationManager.AppSettings["smtpClientUsername"].ToString();
            smtpClientPassword = ConfigurationManager.AppSettings["smtpClientPassword"].ToString();
            mailFrom = ConfigurationManager.AppSettings["mailFrom"].ToString();
            urLString = ConfigurationManager.AppSettings["urLString"].ToString();

            string uristring = urLString;

            Uri url = new Uri(uristring);
            string footer = "Take a decision on this request";
            string Emailhtml = null;

            Emailhtml = "<!DOCTYPE html><head>" +
    "      <meta http-equiv='Content-Type' content='text/html; charset=utf-8'>" +
    "      <meta name='viewport' content='width=device-width, initial-scale=1.0'>" +
    "      <title>Minty-Multipurpose Responsive Email Template</title>" +
    "      <style type='text/css'>" +
    "         /* Client-specific Styles */" +
    "         #outlook a {padding:0;} /* Force Outlook to provide a 'view in browser' menu link. */" +
    "         body{width:100% !important; -webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; margin:0; padding:0;font-family:Helvetica, arial, sans-serif;background-color:#c8c8c8;}" +
    "         /* Prevent Webkit and Windows Mobile platforms from changing default font sizes, while not breaking desktop design. */" +
    "         .ExternalClass {width:100%;} /* Force Hotmail to display emails at full width */" +
    "         .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {line-height: 100%;} /* Force Hotmail to display normal line spacing.  More on that: http://www.emailonacid.com/forum/viewthread/43/ */" +
    "         #backgroundTable {margin:0; padding:0; width:100% !important; line-height: 100% !important;}" +
    "         img {outline:none; text-decoration:none;border:none; -ms-interpolation-mode: bicubic;}" +
    "         a img {border:none;}" +
    "         .image_fix {display:block;}" +
    "         p {margin: 0px 0px !important;}" +
    "         table td {border-collapse: collapse;}" +
    "         table { border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt; }" +
    "         /*a {color: #e95353;text-decoration: none;text-decoration:none!important;}*/" +
    "         /*STYLES*/" +
    "         table[class=full] { width: 100%; clear: both; }" +
    "         /*################################################*/" +
    "         /*IPAD STYLES*/" +
    "         /*################################################*/" +
    "         @media only screen and (max-width: 640px) {" +
    "         a[href^='tel'], a[href^='sms'] {" +
    "         text-decoration: none;" +
    "         color: #ffffff; /* or whatever your want */" +
    "         pointer-events: none;" +
    "         cursor: default;" +
    "         }" +
    "         .mobile_link a[href^='tel'], .mobile_link a[href^='sms'] {" +
    "         text-decoration: default;" +
    "         color: #ffffff !important;" +
    "         pointer-events: auto;" +
    "         cursor: default;" +
    "         }" +
    "         table[class=devicewidth] {width: 440px!important;text-align:center!important;}" +
    "         table[class=devicewidthinner] {width: 420px!important;text-align:center!important;}" +
    "         table[class='sthide']{display: none!important;}" +
    "         img[class='bigimage']{width: 420px!important;height:219px!important;}" +
    "         img[class='col2img']{width: 420px!important;height:258px!important;}" +
    "         img[class='image-banner']{width: 440px!important;height:106px!important;}" +
    "         td[class='menu']{text-align:center !important; padding: 0 0 10px 0 !important;}" +
    "         td[class='logo']{padding:10px 0 5px 0!important;margin: 0 auto !important;}" +
    "         img[class='logo']{padding:0!important;margin: 0 auto !important;}" +
    "         }" +
    "         /*##############################################*/" +
    "         /*IPHONE STYLES*/" +
    "         /*##############################################*/" +
    "         @media only screen and (max-width: 480px) {" +
    "         a[href^='tel'], a[href^='sms'] {" +
    "         text-decoration: none;" +
    "         color: #ffffff; /* or whatever your want */" +
    "         pointer-events: none;" +
    "         cursor: default;" +
    "         }" +
    "         .mobile_link a[href^='tel'], .mobile_link a[href^='sms'] {" +
    "         text-decoration: default;" +
    "         color: #ffffff !important; " +
    "         pointer-events: auto;" +
    "         cursor: default;" +
    "         }" +
    "         table[class=devicewidth] {width: 280px!important;text-align:center!important;}" +
    "         table[class=devicewidthinner] {width: 260px!important;text-align:center!important;}" +
    "         table[class='sthide']{display: none!important;}" +
    "         img[class='bigimage']{width: 260px!important;height:136px!important;}" +
    "         img[class='col2img']{width: 260px!important;height:160px!important;}" +
    "         img[class='image-banner']{width: 280px!important;height:68px!important;}" +
    "         }" +
    "		 .blue-hdr{color:#777;text-transform:uppercase;font-size:18px;}" +
    "		 .black-info{color:#000000;font-size:18px;}" +
    "      </style>" +
    "   </head>" +
    "<body>" +
    "<div class='block'>" +
    "   <!-- Start of preheader -->" +
    "   <table width='100%' cellpadding='0' cellspacing='0' border='0' id='backgroundTable' st-sortable='preheader'>" +
    "      <tbody>" +
    "         <tr>" +
    "            <td width='100%'>" +
    "               <table width='580' cellpadding='0' cellspacing='0' border='0' align='center' class='devicewidth'>" +
    "                  <tbody>" +
    "                     <!-- Spacing -->" +
    "                     <tr>" +
    "                        <td width='100%' height='5'></td>" +
    "                     </tr>" +
    "                     <!-- Spacing -->" +
    "                     <tr>" +
    "                        <td align='right' valign='middle' style='font-size: 10px;color: #999999' st-content='preheader'>" +
    "                           <!--If you cannot read this email, please  <a class='hlite' href='#' style='text-decoration: none; color: #0db9ea'>click here</a> -->" +
    "						   <br/>" +
    "                        </td>" +
    "                     </tr>" +
    "                     <!-- Spacing -->" +
    "                     <tr>" +
    "                        <td width='100%' height='5'></td>" +
    "                     </tr>" +
    "                     <!-- Spacing -->" +
    "                  </tbody>" +
    "               </table>" +
    "            </td>" +
    "         </tr>" +
    "      </tbody>" +
    "   </table>" +
    "   <!-- End of preheader -->" +
    "</div>" +
    "<div class='block'>" +
    "   <!-- start of header -->" +
    "   <table width='100%' cellpadding='0' cellspacing='0' border='0' id='backgroundTable' st-sortable='header'>" +
    "      <tbody>" +
    "         <tr>" +
    "            <td>" +
    "               <table width='750' bgcolor='#cc0000' cellpadding='0' cellspacing='0' border='0' align='center' class='devicewidth' hlitebg='edit' shadow='edit'>" +
    "                  <tbody>" +
    "                     <tr>" +
    "                        <td>" +
    "                           <!-- logo -->" +
    "                           <table width='750' cellpadding='0' cellspacing='0' border='0' align='left' class='devicewidth'>" +
    "                              <tbody>" +
    "                                 <tr>" +
    "                                    <td valign='middle' width='100%' style='padding: 10px 0 10px 20px;font-size: 20px; color: #ffffff;line-height: 28px;' align='left' class='menu' st-content='menu' class='logo'>" +
    "                                       <div class='imgpop'>" +
    "                                          <!--" +
    "										  <a href='#'><img src='img/logo.png' alt='logo' border='0' style='display:block; border:none; outline:none; text-decoration:none;' st-image='edit' class='logo'></a>" +
    "										  -->" +
    "										  <p>BVN Incident Report For BVN :" + BVN.ToUpper() + "</p>" +
    "                                       </div>" +
    "                                    </td>" +
    "                                 </tr>" +
    "                              </tbody>" +
    "                           </table>" +
    "                           <!-- End of logo -->" +
    "                        </td>" +
    "                     </tr>" +
    "                  </tbody>" +
    "               </table>" +
    "            </td>" +
    "         </tr>" +
    "      </tbody>" +
    "   </table>" +
    "   <!-- end of header -->" +
    "</div><div class='block'>" +
    "   <!-- image + text -->" +
    "   <table width='100%' cellpadding='0' cellspacing='0' border='0' id='backgroundTable' st-sortable='bigimage'>" +
    "      <tbody>" +
    "         <tr>" +
    "            <td>" +
    "               <table bgcolor='#ffffff' width='750' align='center' cellspacing='0' cellpadding='0' border='0' class='devicewidth' modulebg='edit'>" +
    "                  <tbody>" +
    "                     <tr>" +
    "                        <td width='100%' height='20'></td>" +
    "                     </tr>" +
    "                     <tr>" +
    "                        <td>" +
    "                           <table width='750' align='center' cellspacing='0' cellpadding='0' border='0' class='devicewidthinner'>" +
    "                              <tbody>" +
    "                                 <tr>" +
    "                                    <!-- start of image -->" +
    "                                    <td width='100%' style='padding: 10px 20px 25px 20px;font-size: 50px; color: #000000;' align='left'>" +
    "									   <span style='color:#555555;'></span> " + AccountName +
    "                                    </td>" +
    "                                 </tr>" +
    "                                 <!-- end of image -->" +
    "                                 <!-- Spacing -->" +
    "                                 <tr>" +
    "                                    <td width='100%' height='20' style='border-top:1px solid #ECECFB;'></td>" +
    "                                 </tr>" +
    "                                 <!-- Spacing -->" +
    "                                 <!-- /button -->" +
    "                                 <!-- Spacing -->" +
    "                                 <tr>" +
    "                                    <td width='100%' height='20'></td>" +
    "                                 </tr>" +
    "                                 <!-- Spacing -->" +
    "                              </tbody>" +
    "                           </table>" +
    "                        </td>" +
    "                     </tr>" +
    "                  </tbody>" +
    "               </table>" +
    "            </td>" +
    "         </tr>" +
    "      </tbody>" +
    "   </table>" +
    "</div>" +
    "<div class='block'>" +
    "   <!-- Start of 2-columns -->" +
    "   <table width='100%' cellpadding='0' cellspacing='0' border='0' id='backgroundTable' st-sortable='2columns'>" +
    "      <tbody>" +
    "         <tr>" +
    "            <td>" +
    "               <table bgcolor='#ffffff' width='750' cellpadding='0' cellspacing='0' border='0' align='center' class='devicewidth' modulebg='edit'>" +
    "                  <tbody>" +
    "                     <tr>" +
    "                        <td>" +
    "                           <table width='700' cellpadding='0' cellspacing='0' border='0' align='center' class='devicewidth'>" +
    "                              <tbody>" +
    "                                 <tr>" +
    "                                    <td>" +
    "                                       <table width='340' align='left' border='0' cellpadding='0' cellspacing='0' class='devicewidth'>" +
    "                                          <tbody>" +
    "                                             <!-- image -->" +
    "                                             <tr style='vertical-align: top;'>" +
    "                                                <td width='340' height='70' align='left' class='devicewidth'>" +
    "													<table width='340' align='left' border='0' cellpadding='0' cellspacing='0' class='devicewidth'>" +
    "														<tbody>" +
    "															<tr>" +
    "																<td class='blue-hdr'>" +
    "																	First Name" +
    "																</td>" +
    "															</tr>" +
    "															<tr>" +
    "																<td width='100%' height='15' style='font-size:1px; line-height:1px; mso-line-height-rule: exactly;border-top:1px solid #ECECFB;padding:1%'>&nbsp;</td>" +
    "															</tr>" +
    "															<tr>" +
    "																<td class='black-info'>" +
                                                                    FirstName +
    "																</td>" +
    "															</tr>" +
    "														</tbody>" +
    "													</table>" +
    "                                                </td>" +
    "                                             </tr>" +
    "                                             <!-- Spacing -->" +
    "                                             <tr>" +
    "                                                <td width='100%' height='15' style='font-size:1px; line-height:1px; mso-line-height-rule: exactly;'>&nbsp;</td>" +
    "                                             </tr>" +
    "                                             <!-- Spacing -->" +
    "                                          </tbody>" +
    "                                       </table>" +
    "                                       <!-- end of left column -->" +
    "                                       <!-- spacing for mobile devices-->" +
    "                                       <table align='left' border='0' cellpadding='0' cellspacing='0' class='mobilespacing'>" +
    "                                          <tbody>" +
    "                                             <tr>" +
    "                                                <td width='100%' height='15' style='font-size:1px; line-height:1px; mso-line-height-rule: exactly;'>&nbsp;</td>" +
    "                                             </tr>" +
    "                                          </tbody>" +
    "                                       </table>" +
    "                                       <!-- end of for mobile devices-->" +
    "                                       <!-- start of right column -->" +
    "                                       <table width='340' align='right' border='0' cellpadding='0' cellspacing='0' class='devicewidth'>" +
    "                                          <tbody>" +
    "                                             <!-- image -->" +
    "                                             <tr style='vertical-align: top;'>" +
    "                                                <td width='340' height='70' align='left' class='devicewidth'>" +
    "													<table width='340' align='left' border='0' cellpadding='0' cellspacing='0' class='devicewidth'>" +
    "														<tbody>" +
    "															<tr>" +
    "																<td class='blue-hdr'>" +
    "																	Last Name" +
    "																</td>" +
    "															</tr>" +
    "															<tr>" +
    "																<td width='100%' height='15' style='font-size:1px; line-height:1px; mso-line-height-rule: exactly;border-top:1px solid #ECECFB;padding:1%'>&nbsp;</td>" +
    "															</tr>" +
    "															<tr>" +
    "																<td class='black-info'>" +
                                                                    LastName +
    "																</td>" +
    "															</tr>" +
    "														</tbody>" +
    "													</table>" +
    "                                                </td>" +
    "                                             </tr>" +
    "                                             <!-- Spacing -->" +
    "                                             <tr>" +
    "                                                <td width='100%' height='15' style='font-size:1px; line-height:1px; mso-line-height-rule: exactly;'>&nbsp;</td>" +
    "                                             </tr>" +
    "                                             <!-- Spacing -->" +
    "                                          </tbody>" +
    "                                       </table>" +
    "                                       <!-- end of right column -->" +
    "                                    </td>" +
    "                                 </tr>" +
    "                              </tbody>" +
    "                           </table>" +
    "                        </td>" +
    "                     </tr>" +
    "                     <tr>" +
    "                        <td width='100%' height='0'></td>" +
    "                     </tr>" +
    "					       <tr>" +
    "                        <td>" +
    "                           <table width='700' cellpadding='0' cellspacing='0' border='0' align='center' class='devicewidth'>" +
    "                              <tbody>" +
    "                                 <tr>" +
    "                                    <td>" +
    "                                       <table width='340' align='left' border='0' cellpadding='0' cellspacing='0' class='devicewidth'>" +
    "                                          <tbody>" +
    "                                             <!-- image -->" +
    "                                             <tr style='vertical-align: top;'>" +
    "                                                <td width='340' height='70' align='left' class='devicewidth'>" +
    "													<table width='340' align='left' border='0' cellpadding='0' cellspacing='0' class='devicewidth'>" +
    "														<tbody>" +
    "															<tr>" +
    "																<td class='blue-hdr'>" +
    "																	Incident Type" +
    "																</td>" +
    "															</tr>" +
    "															<tr>" +
    "																<td width='100%' height='15' style='font-size:1px; line-height:1px; mso-line-height-rule: exactly;border-top:1px solid #ECECFB;padding:1%'>&nbsp;</td>" +
    "															</tr>" +
    "															<tr>" +
    "																<td class='black-info'>" +
                                                                    Irregularity +
    "																</td>" +
    "															</tr>" +
    "														</tbody>" +
    "													</table>" +
    "                                                </td>" +
    "                                             </tr>" +
    "                                             <!-- Spacing -->" +
    "                                             <tr>" +
    "                                                <td width='100%' height='15' style='font-size:1px; line-height:1px; mso-line-height-rule: exactly;'>&nbsp;</td>" +
    "                                             </tr>" +
    "                                             <!-- Spacing -->" +
    "                                          </tbody>" +
    "                                       </table>" +
    "                                       <!-- end of left column -->" +
    "                                       <!-- spacing for mobile devices-->" +
    "                                       <table align='left' border='0' cellpadding='0' cellspacing='0' class='mobilespacing'>" +
    "                                          <tbody>" +
    "                                             <tr>" +
    "                                                <td width='100%' height='15' style='font-size:1px; line-height:1px; mso-line-height-rule: exactly;'>&nbsp;</td>" +
    "                                             </tr>" +
    "                                          </tbody>" +
    "                                       </table>" +
    "                                       <!-- end of for mobile devices-->" +
    "                                       <!-- start of right column -->" +
    "                                       <table width='340' align='right' border='0' cellpadding='0' cellspacing='0' class='devicewidth'>" +
    "                                          <tbody>" +
    "                                             <!-- image -->" +
    "                                             <tr style='vertical-align: top;'>" +
    "                                                <td width='340' height='70' align='left' class='devicewidth'>" +
    "													<table width='340' align='left' border='0' cellpadding='0' cellspacing='0' class='devicewidth'>" +
    "														<tbody>" +
    "															<tr>" +
    "																<td class='blue-hdr'>" +
    "																	Initiator " +
    "																</td>" +
    "															</tr>" +
    "															<tr>" +
    "																<td width='100%' height='15' style='font-size:1px; line-height:1px; mso-line-height-rule: exactly;border-top:1px solid #ECECFB;padding:1%'>&nbsp;</td>" +
    "															</tr>" +
    "															<tr>" +
    "																<td class='black-info'>" +
                                                                    StaffName +
    "																</td>" +
    "															</tr>" +
    "														</tbody>" +
    "													</table>" +
    "                                                </td>" +
    "                                             </tr>" +
    "                                             <!-- Spacing -->" +
    "                                             <tr>" +
    "                                                <td width='100%' height='15' style='font-size:1px; line-height:1px; mso-line-height-rule: exactly;'>&nbsp;</td>" +
    "                                             </tr>" +
    "                                             <!-- Spacing -->" +
    "                                          </tbody>" +
    "                                       </table>" +
    "                                       <!-- end of right column -->" +
    "                                    </td>" +
    "                                 </tr>" +
    "                              </tbody>" +
    "                           </table>" +
    "                        </td>" +
    "                     </tr>" +
    "                     <tr>" +
    "                        <td>" +
    "                           <table width='700' cellpadding='0' cellspacing='0' border='0' align='center' class='devicewidth'>" +
    "                              <tbody>" +
    "                                 <tr>" +
    "                                    <td>" +
    "                                       <table width='340' align='left' border='0' cellpadding='0' cellspacing='0' class='devicewidth'>" +
    "                                          <tbody>" +
    "                                             <!-- image -->" +
    "                                             <tr style='vertical-align: top;'>" +
    "                                                <td width='340' height='70' align='left' class='devicewidth'>" +
    "                                       <table width='340' align='left' border='0' cellpadding='0' cellspacing='0' class='devicewidth'>" +
    "                                          <tbody>" +
    "                                             <tr>" +
    "                                                <td class='blue-hdr'>" +
    "                                                   Comment " +
    "                                                </td>" +
    "                                             </tr>" +
    "                                             <tr>" +
    "                                                <td width='100%' height='15' style='font-size:1px; line-height:1px; mso-line-height-rule: exactly;border-top:1px solid #ECECFB;padding:1%'>&nbsp;</td>" +
    "                                             </tr>" +
    "                                             <tr>" +
    "                                                <td class='black-info'>" +
                                                        Comment +
    "                                                </td>" +
    "                                             </tr>" +
    "                                          </tbody>" +
    "                                       </table>" +
    "                                                </td>" +
    "                                             </tr>" +
    "                                             <!-- Spacing -->" +
    "                                             <tr>" +
    "                                                <td width='100%' height='15' style='font-size:1px; line-height:1px; mso-line-height-rule: exactly;'>&nbsp;</td>" +
    "                                             </tr>" +
    "                                             <!-- Spacing -->" +
    "                                          </tbody>" +
    "                                       </table>" +
    "                                       <!-- end of left column -->" +
    "                                       <!-- spacing for mobile devices-->" +
    "                                       <table align='left' border='0' cellpadding='0' cellspacing='0' class='mobilespacing'>" +
    "                                          <tbody>" +
    "                                             <tr>" +
    "                                                <td width='100%' height='15' style='font-size:1px; line-height:1px; mso-line-height-rule: exactly;'>&nbsp;</td>" +
    "                                             </tr>" +
    "                                          </tbody>" +
    "                                       </table>" +
    "                                       <!-- end of for mobile devices-->" +
    "                                       <!-- start of right column -->" +
    "                                       <table width='340' align='right' border='0' cellpadding='0' cellspacing='0' class='devicewidth'>" +
    "                                          <tbody>" +
    "                                             <!-- image -->" +
    "                                             <tr style='vertical-align: top;'>" +
    "                                                <td width='340' height='70' align='left' class='devicewidth'>" +
    "                                       <table width='340' align='left' border='0' cellpadding='0' cellspacing='0' class='devicewidth'>" +
    "                                          <tbody>" +
    "                                             <tr>" +
    "                                                <td class='blue-hdr'>" +
    "                                                   DATE / TIME" +
    "                                                </td>" +
    "                                             </tr>" +
    "                                             <tr>" +
    "                                                <td width='100%' height='15' style='font-size:1px; line-height:1px; mso-line-height-rule: exactly;border-top:1px solid #ECECFB;padding:1%'>&nbsp;</td>" +
    "                                             </tr>" +
    "                                             <tr>" +
    "                                                <td class='black-info'>" +
                                                        DateTime.Now +
    "                                                </td>" +
    "                                             </tr>" +
    "                                          </tbody>" +
    "                                       </table>" +
    "                                                </td>" +
    "                                             </tr>" +
    "                                             <!-- Spacing -->" +
    "                                             <tr>" +
    "                                                <td width='100%' height='15' style='font-size:1px; line-height:1px; mso-line-height-rule: exactly;'>&nbsp;</td>" +
    "                                             </tr>" +
    "                                             <!-- Spacing -->" +
    "                                          </tbody>" +
    "                                       </table>" +
    "                                       <!-- end of right column -->" +
    "                                    </td>" +
    "                                 </tr>" +
    "                              </tbody>" +
    "                           </table>" +
    "                        </td>" +
    "                     </tr>" +
    "                  </tbody>" +
    "               </table>" +
    "            </td>" +
    "         </tr>" +
    "      </tbody>" +
    "   </table>" +
    "   <!-- End of 2-columns -->" +
    "</div>" +
    "<div class='block'>" +
    "   <!-- Start of preheader -->" +
    "   <table width='100%' cellpadding='0' cellspacing='0' border='0' id='backgroundTable' st-sortable='postfooter'>" +
    "      <tbody>" +
    "         <tr>" +
    "            <td width='100%'>" +
    "               <table width='750' bgcolor='#444444' cellpadding='0' cellspacing='0' border='0' align='center' class='devicewidth'>" +
    "                  <tbody>" +
    "                     <!-- Spacing -->" +
    "                     <tr>" +
    "                        <td width='100%' height='5'></td>" +
    "                     </tr>" +
    "                     <!-- Spacing -->" +
    "                     <tr>" +
    "                        <td align='center' valign='middle' style='font-size: 12px;color: #fff;padding:1%' st-content='preheader'>" +
    "<a href='" + url + "' style='text-decoration:none !important;color:whitesmoke;font-size:1em;'>" +
    footer + "</preferences>" +
    "</a>" +
    "                        </td>" +
    "                     </tr>" +
    "                     <!-- Spacing -->" +
    "                     <tr>" +
    "                        <td width='100%' height='5'></td>" +
    "                     </tr>" +
    "                     <!-- Spacing -->" +
    "                  </tbody>" +
    "               </table>" +
    "            </td>" +
    "         </tr>" +
    "      </tbody>" +
    "   </table>" +
    "   <!-- End of preheader -->" +
    "</div>" +
    "</body></html>";

            string result = "";
         //   string mailFrom = "oyeyemi.oyetoro@zenithbank.com";
            string subject = "BVN Incident Report for "+ BVN;
            string mailBody = Emailhtml.ToString();
            // mailBody.IsBodyHtml = true;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtpClient);



                //string cid = mail.AddRelatedFile("dude.gif");
                //htmlBody = mail.Replace("IMAGE_CID", cid);


                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailBody, null, "text/html");

                //Add Image
                //LinkedResource theEmailImage = new LinkedResource("C:\\facebook.png");
                //theEmailImage.ContentId = "myImageID";
                //htmlView.LinkedResources.Add(theEmailImage);
                mail.AlternateViews.Add(htmlView);
                mail.From = new MailAddress(mailFrom);
                mail.To.Add(mailTo);
                mail.Subject = subject;
                mail.Body = mailBody;
                mail.IsBodyHtml = true;
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential(smtpClientUsername, smtpClientPassword);
                SmtpServer.EnableSsl = false;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Send(mail);
                result = "00-Message Sent";
            }
            catch (Exception ex)
            {
                result = "01-Error Occurred: " + ex.Message;
            }
            return result;
        }
    }
}
