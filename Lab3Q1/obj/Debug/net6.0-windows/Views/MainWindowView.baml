   M S B A M L   `   `   `  ����A  =Lab3Q1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Lab3Q1.ViewsLab3Q1.Views  5      5clr-namespace:Lab3Q1.ViewModelsLab3Q1.ViewModels  67   !    Lab3Q1.Views.MainWindowView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Lab3Q1.Views     5      6
viewmodelsclr-namespace:Lab3Q1.ViewModels     67   Hi:http://schemas.microsoft.com/expression/2010/interactivity     5      8	behaviors"using:Microsoft.Toolkit.Mvvm.Input     5      .��5      ��   �� Orientation$  Vertical=�6   .+�5   
   o� $��20��6   $	��Top=�6   .@�5      m� $
��File��6   $��20��6%   $��30��61   $
��Left=�5      .@�5      m� $
��Open��6   $��20��6)   $	��150��65   $
��Left=�5      �� 5      $��1��6   $	��150��6'   $
��Left=�5      m� 5      $
��Exit��6   $��20��6)   $	��150��65   $
��Left=�5       m� InputGestureText$ Alt + F4��5       m� Command 5      �� *ExitCommand+5      5      � 5   
    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5       $
��auto �6#   .+�5"      �� $��0��6      CompanyLogo#��[  6$   $��/Images/icon.png��5#      �� 5&      $��1��6   $  Vertical=�5'      $
��Left=�60   .+�5)      ��   Instruction#��[ 6   $��Instruction:��6=   �� 5*      #��[ 6   $F��@Category: Please select the certain category on the category box��6=   �� 5+      #��[ 6   $G��AAdd: Please select the item on the food menu and press add button��6=   �� 5,      #��[ 6   $i��cEdit: Please select the item on the order list and enter the edit amount then press the edit button��6=   �� 5-      #��[ 6   $N��H(If the edit amount is ZERO, it will removes the item on the order list)��6=   �� 5.      #��[ 6   $N��HDelete: Please select the item on the order list and press delete button��6=   5/      50      �� 54   
   $  
Horizontal=�6   $��20 10q�55      .+�57      �  � RowDefinitions 58      �� 59      $��50 �6$   �� 5:      $	��420 �6$    5<      �� 5=      $	��200 �6'   �� 5>      $	��380 �6'   .+�5B      �� $��0��6   $��0��6)   $��Category��5C        CategoryText#��[ 5D      �� 5E      -   5         ��Name$ categoryComboBox��5E       �� SelectedIndex$ 0��5G   E   $��0��5H      $��1��6(   $	��200��5I      $��10q�6'   ��5F      �� *
Category+ �� SelectedItem 5G      �� *SelectedCategory+5J      &   System.Windows.Controls.DataGrid  5M      -   5          Name$ menuDataGrid��5M      $��1��5N      $��0��6(   $��2��68   	   AutoGenerateColumns$	 False��5P      
   
IsReadOnly$

 True��67   ��5O      �� *Foods+ 69   �� *SelectedItem+   Columns 5R      0  *System.Windows.Controls.DataGridTextColumn  5S      ,  &System.Windows.Controls.DataGridColumn   Header$ Category��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6?   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5T   -   �� *
Category+  5U      $
 Name��6-   $	 200 6;    5V   -   �� *Name+  5W      $ Price��6-   $ * 6<    5X   -   �� *Price+5Z      5[      � 5^      $��Center=�6   $��Center=�6.    5_      �� 5`      $
��auto �6$   �� 5a      $
��auto �6$   �� 5b      $
��auto �6$   �� 5c      $
��auto �6$   .+�5f      �� $	��Add��6   $��0��5g      $��20 10 20 10q�5h      $��
20 20 0 20q�5i      ��5j      �� *AddSelectedItem+�� 5l      $
��Edit��6   $��1��5m      $��20 10 20 10q�5n      $��
20 20 0 20q�5o      ��5p      �� *EditSelectedItem+�� 5r      $��2��6   $��20 0 0 0q�6'    �� TextAlignment$ Center=�5t      ��5s      �� *
EditAmount+5t      �� 5v      $��Delete��6   $��3��5w      $��20 10 20 10q�5x      $��
20 20 0 20q�5y      ��5z      �� *DeleteSelectedItem+5{      � 5~      $	��580��6   $��20 0 0 0q�5       5�      �� 5�      $��50 �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$    5�      �� 5�      $��* �6'   .+�5�      �� $��Order Details��6   $��0��5�        
OrderTitle#��[ 5�        5�      -   5        $ orderDataGrid��5�      $��1��5�      $	��250��5�      $	 False��5�      $

 True��67   ��5�      �� *SelectedFoods+ 5�      �� *SelectedOrderItem+ 5�        5�      $ Category��6-   $	 145 6?    5�   -   �� *
Category+  5�      $
 Name��6-   $	 145 6;    5�   -   �� *Name+  5�      $ Price��6-   $	 145 6<    5�   -   �� *Price+  5�      $ Amount��6-   $ * 6=    5�   -   �� *Amount+5�      � 5�      $��2��6   $��0 20 0 0q�6$    5�      �� 5�      $��40 �6(   �� 5�      $��40 �6(   �� 5�      $��40 �6(   �� 5�      $��* �6(    5�      �� 5�      $	��100 �6+   �� 5�      $	��200 �6+   �� 5�      $
��auto �6+   .+�5�      �� $��0��6    $��0��6-     	OrderText#��[ 5�       $��	Sub-Total��5�       �� 5�      $��0��6    $��1��6-   #��[ 5�       ��5�       �� *
SubTotal+�� 5�      $��1��6    $��0��6-   #��[ 5�       $	��Tax��5�       �� 5�      $��1��6    $��1��6-   #��[ 5�       ��5�       �� *Tax+�� 5�      $��2��6    $��0��6-   #��[ 5�       $��Total��5�       �� 5�      $��2��6    $��1��6-   #��[ 5�       ��5�       �� *Total+�� 5�      -   5         ��Name$ OrderButton��5�      $��2��5�      $��2��6*   $��	New Order��5�      $��80 0 0 0q�5�      $
��20 0q�5�        OrderButton#��[ 5�      ��5�      �� *NewOrderClick+5�      5�      5�      �� 5�   
   $��0 0 0 0q�6   .@�5�      �� .��5�      �� -   5         ��Name$ HyperLinkWebsite��5�      $��http://www.google.com?�5�       �� Command 5�      �� *HyperLinkCommand+ �� CommandParameter 5�      ��  �� ElementName$ HyperLinkWebsite�� �� Path$ NavigateUri�.�6h   .�5�      �� $��0��6     FooterCompanyLogo#��[ 6,   $��/Images/icon.png��5�   !   5�      5�      �� 5�      .��5�      �� #��[ 6   $��Ka Wai Wong - 301201043��6=   5�      5�      5�      5�      