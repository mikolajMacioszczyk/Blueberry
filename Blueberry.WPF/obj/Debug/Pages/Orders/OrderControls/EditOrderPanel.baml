   M S B A M L   `   `   `  ����H  DBlueberry.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Blueberry.WPF.DialogBoxesBlueberry.WPF.DialogBoxes  5      =    7Blueberry.WPF.Pages.Orders.OrderControls.EditOrderPanel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;dialogs'clr-namespace:Blueberry.WPF.DialogBoxes     5      .��5	      �� $��20q�6     � 	Resources  5
   
    �� 
TargetType   ButtonStyle �� Property �� Value  ComboBoxStyle  TextboxStyle  TextBoxStyle(  "System.Windows.Controls.DatePicker  DatePicerStyle��%�  &	        &	 �     &	 R    &	 �    &	 A    �� 5      " ��6   .�5      ��  � ��$ 20q�6+   �� 5       � ��$ Center=�68   �� 5       � ��$ 0,0,1,1q�64   �� 5       � ��
 ��� �6/   �� 5       � ��$	 150��6*   5      �� 5      " ��6   .�5      ��  � ��
 �����6/   �� 5       � ��$ 10q�6+   5      �� 5      " ��6   .�5      ��  � ��$
 10,5q�6+   5      �� 5      " ��6   .�5      ��  � ��$
 10,5q�6+   �� 5       � ��$	 150��6-   �� 5       �@��TextAlignment$ Center=�62   5      �� 5      "  6   .�5      ��  � ��$
 10,5q�6+   �� 5        � ��$ Center=�6?   5!      5"      .+�5$   
   0   *Blueberry.WPF.DialogBoxes.MessageDialogBox  -   5          Name$ SubmitDialogBox��5%      )   #Blueberry.WPF.DialogBoxes.DialogBox   Caption$. (Czy na pewno chcesz zatwierdzić zmiany?��5&         Buttons$ YesNo=�5(         Icon$ Question=�5)         
CommandYes 5'      �� 	 �� Path$	 SubmitCommand�5)      5   /Blueberry.WPF.DialogBoxes.NotificationDialogBox  5+   
   -   5        
  Name$
 DiscardDialogBox��5,      $ Zmiany zostały wycofane��5-      0   *Blueberry.WPF.DialogBoxes.CommandDialogBox   CommandAfter 5.      �� $	 DiscardCommand��� 50   
   #��[ 51      
����� �$
��Bold"�6L   ��50      �� $	 SelectedOrder.Customer� �� StringFormat$ Klient: {0}��51   L   �� 53   
    �� Orientation$ 
Horizontal=�6   .+�54      �� $��	Ilość: ��6   #��[ 6'   �� 55      #��[ 63   ��6   �� $	 Amount�63   56      �� 58   
   $ 
Horizontal=�6   .+�59      �� $��
Priorytet:��6   #��[ 6*   �� 5:      #��[ 5<      ��5:      �� $	 
Priorities� �� SelectedItem 5;      �� $	 SelectedPriority�5<      5=      �� 5?   
   $ 
Horizontal=�6   .+�5@      �� $��Status:��6   #��[ 6'   �� 5A      #��[ 5D      ��5A      �� $	 Statuses� 5B      �� $	 SelectedStatus� �� Text 5C      �� $	 SelectedStatus�5D      5E      �� 5G   
   $ 
Horizontal=�6   .+�5H      �� $��Data przyjęcia:��6   #��[ 6/     5I      #��[ 6<      SelectedDate 6   �� *	OrderDate+6<   5J      �� 5L   
   $ 
Horizontal=�6   .+�5M      �� $��Data realizacji:��6   #��[ 60     5N      #��[ 6B    6   �� *RealizationDate+6B   5O      �� 5Q   
   $ 
Horizontal=�6   .+�5R      �� $��
Zatwierdź��6   #��[  5T      ��5S      ��  �� ElementName$ SubmitDialogBox��$
	 Show�5T      �� 5U      $��Anuluj��6   #��[  5W      ��5V      �� $ DiscardDialogBox��$
	 Show�5W      5X      5Y      5Z      