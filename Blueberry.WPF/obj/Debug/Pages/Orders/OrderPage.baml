   M S B A M L   `   `   `  ����H  DBlueberry.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Blueberry.WPF.Pages.OrdersBlueberry.WPF.Pages.Orders  5      C&clr-namespace:Blueberry.WPF.ConvertersBlueberry.WPF.Converters  5      c6clr-namespace:Blueberry.WPF.Pages.Orders.OrderControls(Blueberry.WPF.Pages.Orders.OrderControls  5      #    Blueberry.WPF.Pages.OrderPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?
viewModels(clr-namespace:Blueberry.WPF.Pages.Orders     5      =
converters&clr-namespace:Blueberry.WPF.Converters     5      PorderControls6clr-namespace:Blueberry.WPF.Pages.Orders.OrderControls     5      $	��800��5        N� FontSize$  30(�5       N� Title$ 	OrderPage��5       N� 
Background
 ����� � 	Resources 5      ,   &Blueberry.WPF.Pages.Orders.OrderPageVM 	  Model8   2Blueberry.WPF.Converters.BoolToVisibilityConverter  VisibilityConverter��%:   &	        &	        5   
   6!     5   
   6/   5      .��5      ]�  � DataContext# [  6    5   
    �� 
TargetType $  RadioButtonStyleHorizontalMargin �� Property �� Value  OuterBorderStyle �� Triggers	 P� Property
 P� Value " RadioButtonStyleVerticalMargin��%Y  &	       &	 n     &	 �    �� 5      " 	�6   .�5      ��  � ��$
 10,0q�6+   �� 5       � ��$ 25(�6-   5      �� 5      " ��6   .�5      ��  � ��$ 10q�6+   �� 5       �@��Padding$ 5q�6,   �� 5       �@��CornerRadius$ 10��61   �� 5       � ��$ 2q�64   �� 5       � �� �#00422560    5      P� 5       	 �@J�IsMouseOver
 . . �5!      ��  �@�Cursor$
 Hand��63   5"      5$      �� 5%      " 	�6   .�5&      ��  � ��$ 25(�6-   �� 5'       � ��$	 0,3q�6+   5(      5)      .+�5,   
   �� $
��Left=�6   $��0,0,3,0q�5-      ���#004225 �� Padding$ 
10,5,15,10q�5.      ._�5/      �  � RowDefinitions 50      �� 51      $
��Auto �6$   �� 52      $
��Auto �6$   �� 53      $��* �6$   �� 54      $
��Auto �6$   �� 55      $
��Auto �6$   .+�59      �� $��0��6   ��5:      �� 5;      $��Sortuj po: ��6    .��5=      ��  �� Orientation$ Vertical=�6!   .+�5>      	� $��Dacie��6&    d� 	IsChecked$
 TrueY�66   $��0��5?   K   #��[ 5@   &   ��5?   &   ��  �� Path$ SortCommand�5@   &   	� 5A      $��Kliencie��6&   $��1��5B   K   #��[ 5C   &   ��5B   &   �� $ SortCommand�5C   &   	� 5D      $��Priorytecie��6&   $��2��5E   K   #��[ 5F   &   ��5E   &   �� $ SortCommand�5F   &   5G      5H      �� 5K      $��1��6    5L      ��%    5N      ��5O      �� 5P      $��Zamówienia��6    .��5R      �� $ Vertical=�6!   .+�5S      	� $��Oczekujące��6&   $��0��5T   M   #��[ 5U   &   ��5T   &   �� $ SelectCommand�5U   &   	� 5V      $��Zrealizowane��6&   $��1��5W   M   #��[ 5X   &   ��5W   &   �� $ SelectCommand�5X   &   	� 5Y      $��	Anulowane��6&   $��2��5Z   M   #��[ 5[   &   ��5Z   &   �� $ SelectCommand�5[   &   	� 5\      $��
Odłożone��6&   $��3��5]   M   #��[ 5^   &   ��5]   &   �� $ SelectCommand�5^   &   5_      5`      �� 5c      $��3��6   #��[ 6&   ._�5d      �� $��0q�6   $	��New��5f      ��5e      �� $ ChangeContentCommand���5g      �� 5h       �� Color$ White��6.    �� Opacity$	 0.5Q�6<   .��5j      �� $ 
Horizontal=�6%   .+�5k      �� $��
Dodaj nowe��6$   �� 5l      $ ��../../Images/add_icone.png��6$   $��60��6H   5m      5n      5o      �� 5r      $��4��6   #��[ 6&   ._�5s      �� $��0q�6   $
��List��5u      ��5t      �� $ ChangeContentCommand���5v      �� 5w      $ White��6.   $	 0.5Q�6<   .��5y      �� $ 
Horizontal=�6%   .+�5z      �� $��Lista��6$   �� 5{      $��../../Images/list.png��6$   $��60��6C   5|      5}      5~      5      5�      �� 5�   
   .��5�      >� ��6   �� $ Content�5�      5�      5�      