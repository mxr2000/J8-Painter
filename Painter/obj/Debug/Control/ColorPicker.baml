   M S B A M L   `   `   `  ����B  >Painter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Painter.ControlPainter.Control  5      !    Painter.Control.ColorPicker   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Painter.Control     5      -   5          >�Name$  colorPicker��5	      .��5
      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      �� 5      $��50 �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��Center=�6   R62   �� 5   
   $��1��6   $��Center=�6!   B6?   �� 5   
   $��2��6   $��Center=�6!   G6?   �� 5   
   -   5         ��Name$ 	sliderRed��5   9   $��1q�6   $��1��6   $��0��6,    � Minimum$ 0Q�6L    � Maximum$	 255Q�6X    � Value 5      ��  �� ElementName$ colorPicker�� �� Path$	 Red��� 5   
   -   5        $ 
sliderBlue��5   9   $��1q�6   $��1��6   $��1��6,   $ 0Q�6M   $	 255Q�6Y    5      �� $ colorPicker��$
 Blue��� 5   
   -   5        $ sliderGreen��5   9   $��1q�6   $��1��6   $��2��6,   $ 0Q�6N   $	 255Q�6Z    5      �� $ colorPicker��$ Green��� 5   
   $��2��6   $��3��6$   
���   �$��1��6D   ��5      �� 5       	 �� Color	 6"   �� $ colorPicker��$ Color�5"      5#      5$      