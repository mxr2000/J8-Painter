   M S B A M L   `   `   `  ����B  >Painter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PainterPainter  5   	   1clr-namespace:Painter.ControlPainter.Control  5   	       Painter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Painter     5   	   1controlclr-namespace:Painter.Control     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��38 �6   �� 5      �� 5      $	��200 �6   .+�5   
   �� .+�5      �� -   5         ��Name$ 
lbElements��5      ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value 5      �� 5   "    �� 
TargetType" ��62   .R�5   &   �  5   *   �� 5   .   $��2 �6?   �� 5   .   .+�5   *   ��  ��Name$ leftRect��64   
�������6F   �� 5   *    ��Name$ Bd��6A   $��1��61   #��z��6M   #��z��6y   #��z��6�   	 �� Padding#	 z��6�   
 J� SnapsToDevicePixels
 . ._�5   .   �� #��z��6?   #
 z
 6�   #��z��6�   5    +   5!   '    �� Triggers 5"   &   P� 5#   *    P� Property �@��
IsSelected P� Value .  �5$   .   �� 5%   2    �� 
TargetName$ leftRect��69    � ��
 ��  �6_   5'   +   P� 5(   *    �@J�IsMouseOver .  �5)   .   �� 5*   2   $ leftRect��69    � ��
 ��ح�6_   5,   +   5.   #   50      �� 51       � ��$ 0q�64   52      .@�54      �� .��55      �� $��Image/line.png��6   56      �� 57      .��58      �� $��Image/circle.png��6   59      �� 5:      .��5;      �� $��Image/ellipse.png��6   5<      �� 5=      .��5>      �� $��Image/rectangle.png��6   5?      �� 5@      .��5A      �� $��Image/pencil.png��6   5B      �� 5C      .��5D      �� $��Image/text.png��6   5E      �� 5F      .��5G      �� $��Image/picture.png��6   5H      5I      �� 5J      -   5         ��Name$ btnUndo��5J      
������ .��5K      �� $��Image/undo.png��6   5L      �� 5M      -   5        $ 	btnZoomIn��5M      
������ .��5N      �� $��Image/zoom_in.png��6   5O      �� 5P      -   5        $ btnErase��5P      
������ .��5Q      �� $��Image/erase.png��6   5R      5S      #   Painter.Control.PainterCanvas  5T   
   -   5          Name$ canvas��5T       $��1��60   
�������5U      � 5V   
   $��2��6    � RowDefinitions 5W      �� 5X      $
��Auto �6    �� 5Y      $
��Auto �6    �� 5Z      $��* �6    .+�5\      �� $��color��6   $��2q�6&   .��5]      !   Painter.Control.ColorPicker  -   5          Name$ colorPicker��5]   &   !   Painter.Control.ColorPicker   ColorChanged$ ColorPicker_ColorChanged��6;   5^      �� 5_      $��stroke��6   $��1��6'   $��2q�64   .��5`      �� -   5         ��Name$ sliderStroke��5`   2    � Minimum$ 0Q�6    � Maximum$ 10Q�6%   6u   5a      5b      5c      5d      