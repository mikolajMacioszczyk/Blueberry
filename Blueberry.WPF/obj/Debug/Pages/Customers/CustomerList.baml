   M S B A M L   `   `   `  ����H  DBlueberry.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Blueberry.WPF.Pages.CustomersBlueberry.WPF.Pages.Customers  5      0    *Blueberry.WPF.Pages.Customers.CustomerList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Blueberry.WPF.Pages.Customers     5      .��5	      ��   � 	Resources  5
   
   2   ,Blueberry.WPF.Pages.Customers.CustomerListVM 	  Model �� 
TargetType  ButtonStyle �� Property �� Value �� Triggers P� Property P� Value��%w  &	        &	        5      6#   �� 5      " ��6   .�5      ��  � ��$	 150��6*   �� 5       � ��$	 8,3q�6,   �� 5       � ��$
 0, 5q�6+   �� 5       � �� �#b8c4dd6/   �� 5       � ��$ 0q�64    5      P� 5       �@J�IsMouseOver . . �5      ��  �@�Cursor$
 Hand��63   5      5      5      .��5   
   ��  � DataContext# [  6   ��6<   ��  �� Path$ 	Customers���5      �� 5      .R�5      � 5      ��5       �� 5!      .R�5"      �� 	 �� Padding$	 10q�6   
 �� CornerRadius$
 10��6*   ���#b8c4dd$��1,1,3,3q�6R   $��10q�6l   ��5#      �� 5$       �� Color$ White��6.    �� Opacity$
 0.85Q�6<   ._�5&      �� $	��345��6%   .+�5(      �  � ColumnDefinitions 5)   "   �� 5*   &   �� 5+   &   .+�5.   "   �� $��0��6L    �� TextAlignment$
 Left=�6\   ��6,   �� $ 	FirstName�6\   �� 5/   "   $��1��6K   $
 Left=�6[   ��6,   �� $ LastName�6[   50      �� 53      ��6(   �� $ Number�� 56       57   "   �� 58   &   $
��2.5* �67   �� 59   &   $��2* �67   �� 5:   &   $��* �67   .+�5=   "   �� $��24(�6O   $��0��6]   $
��Left=�6m   ��6,   �� $ Address.City�6m   �� 5>   "   $��24(�6Q   $��1��6_   $
��Left=�6o   ��6,   �� $ Address.Street�6o   �� 5?   "   $��24(�6P   $��2��6^   $
��Left=�6n   ��6,   �� $ Address.House�6n   5@      � 5C       5D   "   �� 5E   &   �� 5F   &   .+�5I   "   �� $��
Szczególy��6)   $��0��6=   #��[ 5J   )   ��5K   )   ��  �� RelativeSource ��  �� AncestorType" ��$  DataContext.DetailsCommand���5L   )   �� �� 5M   "   $��Edytuj��6)   $��1��6:   #��[ 5N   )   ��5O   )   ��  �� " ��$ DataContext.EditCommand���5P   )   �� 5Q      5R      5S      5T      5V      5W      5X      