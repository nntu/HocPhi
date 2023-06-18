<span style="font-family: Roboto">
<p class="p_tieude"><strong><span class="header1">{{ tienNop.Phong_GD }}</span> <br></strong><strong><span class="header1">{{ tienNop.TenTK_Nop }} </span></strong></p><strong><span style="font-size: 19px">
<p class="p_tieude_center" align="center"><strong><span style="font-size: 19px">&nbsp;</span> </strong><strong><span style="font-size: 19px">{{ tienNop.Thong_bao }}</span> </strong></p>
<p class="p_tieude_center" align="center"><span style="font-size: 19px">{{ tienNop.Ky_nop }}</span> </p>
<p class="p_tieude_center" align="center">&nbsp;</p></span></strong>
<p class="p_tieude"><span class="chu">Kính gửi: Quý phụ huynh,</span> <br><span class="chu">Họ và tên học sinh:</span> <strong><strong><span style="font-size: 19px; color: red">{{ tienNop.Hoten_HocSinh }}</span> <br></strong><span class="chu">Lớp <strong>:&nbsp;</strong> </span><strong><span style="font-size: 19px; color: red">{{ tienNop.Lop }}</span> </strong><strong><span class="chu">&nbsp; &nbsp; &nbsp;&nbsp;</span> <br></strong><span class="chu">Mã học sinh <strong>:&nbsp;</strong> </span><strong><span style="font-size: 19px; color: red">{{ tienNop.ma_hs }}</span> </strong>
<p>
<table class="mainTable" style="" width="700">
<tbody>
<tr>
<td height="41"><span style="font-family: Roboto">&nbsp; Lựa chọn 1: thanh toán TỪNG KHOẢN THU (quét theo từng mã QRcode bên dưới)</span></td>
<td><span style="font-family: Roboto">&nbsp;Lựa chọn 2: thanh toán TỔNG SỐ TIỀN (quét 01 mã QRcode bên dưới)</span></td></tr>
<tr>
<td height="350"><span style="font-family: Roboto">
<table class="demTable" style="">
<tbody>
<tr>
<th height="30" scope="col">STT</th>
<th scope="col">Loại Thu</th>
<th scope="col">Mức thu</th>
<th scope="col">QR</th></tr>{% for item in tieumuc %} 
<tr>
<td>{{ item.STT }}</td></tr></tbody></table></span>
<td><span style="font-family: Roboto">{{ item.Muc }}</span></td>
<td><span style="font-family: Roboto">{{ item.sotien | format_number:"N0" }}</span></td>
<td><span style="font-family: Roboto"><img style="height: 83pt; width: 83pt" alt="image" src="{{ item.QRcode }}"> </span></td>{% endfor %} 
<tr>
<td colspan="2"><span style="font-family: Roboto">Tổng Cộng <br></span></td>
<td><span style="font-family: Roboto; color: #ff0000"><strong>{{ tienNop.Tong_So_Tien | format_number:"N0" }}</strong> </span></td>
<td></td></tr></td></tr></tbody></table></strong></span>
<td height="350"><span style="font-family: Roboto">
<p><img style="height: 141pt; width: 141pt" alt="image" src="{{ qrcode_full }}"> <br></p>
<p>Tổng Cộng: <span style="color: #ff0000"><strong>{{ tienNop.Tong_So_Tien | format_number:"N0" }}</strong> </span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="color: #ff0000"><strong><br></strong></span></p></span></td>
<p style="font-size: 15px; text-align: justify; margin: 0in 0in 8pt; line-height: 20pt"><em><span class="span_t">+ <strong><u>Lưu ý:</u> </strong>Quý phụ huynh dùng app các Ngân hàng (như Smartbanking của BIDV, VCB…) hoặc các ví điện tử (như Zalopay,…) để lựa chọn 1 trong 2 cách quét QRcode trên để thanh toán tiền học cho con , vui lòng không điều chỉnh nội dung chuyển tiền. <br></span></em></p>