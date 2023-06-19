 <style>
   .p_tieude {
     margin-top: 0in;
     margin-right: 0in;
     margin-bottom: 0in;
     margin-left: 0in;
     line-height: 18.0pt;
     font-size: 15px;
     font-family: "Roboto";
   }

   .p_tieude_center {
     margin-top: 0in;
     margin-right: 0in;
     margin-bottom: 0in;
     margin-left: 0in;
     line-height: 18.0pt;
     font-size: 15px;
     font-family: "Roboto", sans-serif;
     text-align: center;
   }

   .span_t {
     font-size: 17px;
     font-family: "Roboto";
   }

   .mainTable {
     border: 1px solid #b3adad;
     border-collapse: collapse;
     padding: 1px;
   }

   .mainTable th {
     border: 1px solid #b3adad;
     padding: 1px;
     background: #f0f0f0;
     color: #313030;
   }

   .mainTable td {
     border: 1px solid #b3adad;
     text-align: center;
     padding: 1px;
     background: #ffffff;
     color: #313030;
   }

   .demTable {
     width: 100%;
     height: 100%;
     border: 1px solid #b3adad;
     border-collapse: collapse;
     padding: 1px;
   }

   .demTable th {
     border: 1px solid #b3adad;
     padding: 1px;
     background: #f0f0f0;
     color: #313030;
   }

   .demTable td {
     border: 1px solid #b3adad;
     text-align: center;
     padding: 1px;
     background: #ffffff;
     color: #313030;
   }
   .header1 {
     font-size: 17px;
     font-family: "Roboto";
     color: red;
   }

   .chu {
     font-size: 19px;
     font-family: "Roboto";
     color: black;
   }
 </style>
 <p class="p_tieude">
   <strong>
     <span class="header1">{{ tienNop.Phong_GD }}</span>
   </strong>
 </p>
 <p class="p_tieude">
   <strong>
     <span class="header1">{{ tienNop.TenTK_Nop }} </span>
   </strong>
 </p>
 <p class="p_tieude_center">
   <strong>
     <span style='font-size:19px;font-family:"Roboto";'>&nbsp;</span>
   </strong>
 </p>
 <p class="p_tieude_center">
   <strong>
     <span style='font-size:19px;font-family:"Roboto";'>{{ tienNop.Thong_bao }}</span>
   </strong>
 </p>
 <p class="p_tieude_center">
   <span style='font-size:19px;font-family:"Roboto";'>{{ tienNop.Ky_nop }}</span>
 </p>
 <p class="p_tieude_center">
   <span style='font-size:19px;font-family:"Roboto";'>&nbsp;</span>
 </p>
 <p class="p_tieude">
   <span class="chu">Kính gửi: Quý phụ huynh,</span>
 </p>
 <p style='margin-top:0in;margin-right:0in;margin-bottom:0in;margin-left:0in;line-height:18.0pt;font-size:15px;font-family:"Roboto";text-align:justify;'>
   <span class="chu">Họ và tên học sinh:</span>
   <strong>
     <strong>
       <span style='font-size:19px;font-family:"Roboto";color:red;'>{{ tienNop.Hoten_HocSinh }}</span>
     </strong>
     <span class="chu">Lớp <strong>:&nbsp;</strong>
     </span>
     <strong>
       <span style='font-size:19px;font-family:"Roboto";color:red;'>{{ tienNop.Lop }}</span>
     </strong>
     <strong>
       <span class="chu">&nbsp; &nbsp; &nbsp;&nbsp;</span>
     </strong>
     <span class="chu">Mã học sinh <strong>:&nbsp;</strong>
     </span>
     <strong>
       <span style='font-size:19px;font-family:"Roboto";color:red;'>{{ tienNop.ma_hs }}</span>
     </strong>
 </p>
 <table width="700" class="mainTable">
   <tbody>
     <tr>
       <td height="41">&nbsp; Lựa chọn 1: thanh toán TỪNG KHOẢN THU (quét theo từng mã QRcode bên dưới)</td>
       <td>&nbsp;Lựa chọn 2: thanh toán TỔNG SỐ TIỀN (quét 01 mã QRcode bên dưới)</td>
     </tr>
     <tr>
       <td height="350">
         <table class="demTable">
           <tbody>
             <tr>
               <th height="30" scope="col">STT</th>
               <th scope="col">Loại Thu</th>
               <th scope="col">Mức thu</th>
               <th scope="col">QR</th>
             </tr> {% for item in tieumuc %} <tr>
               <td>{{ item.STT }}</td>
               <td>{{ item.Muc }}</td>
               <td>{{ item.sotien | format_number:"N0" }}</td>
               <td>
                 <img style="width: 83pt; height: 83pt;" src="{{ item.QRcode }}" alt="image" />
               </td>
             </tr> {% endfor %} <tr>
               <td colspan="2">Tổng Cộng <br>
               </td>
               <td>
                 <span style="color: #ff0000;">
                   <strong>{{ tienNop.Tong_So_Tien | format_number:"N0" }}</strong>
                 </span>
               </td>
               <td></td>
             </tr>
           </tbody>
         </table>
       </td>
       <td height="350">
         <p>
           <span>
             <img style="width: 141pt; height: 141pt;" src="{{ qrcode_full }}" alt="image">
           </span>
           <br>
         </p>
         <p>
           <span>Tổng Cộng: </span>
           <span style="color: #ff0000;">
             <strong>{{ tienNop.Tong_So_Tien | format_number:"N0" }}</strong>
           </span>
         </p>
         <p>&nbsp;</p>
         <p>&nbsp;</p>
         <p>
           <span style="color: #ff0000;">
             <strong>
               <br>
             </strong>
           </span>
         </p>
       </td>
     </tr>
   </tbody>
 </table>
 <p style='margin-top:0in;margin-right:0in;margin-bottom:8.0pt;margin-left:0in;line-height:20.0pt;font-size:15px;font-family:"Roboto";text-align:justify;'>
   <em>
     <span class="span_t">+ <strong>
         <u>Lưu ý:</u>
       </strong> Quý phụ huynh dùng app các Ngân hàng (như Smartbanking của BIDV, VCB…) hoặc các ví điện tử (như Zalopay,…) để lựa chọn 1 trong 2 cách quét QRcode trên để thanh toán tiền học cho con , vui lòng không điều chỉnh nội dung chuyển tiền. </span>
   </em>
 </p>