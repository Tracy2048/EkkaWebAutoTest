   M S B A M L   `   `   `  ����M  IEkkaWebAutoTest.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EkkaWebAutoTest.UIEkkaWebAutoTest.UI  5   	   #    EkkaWebAutoTest.UI.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:EkkaWebAutoTest.UI     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   �� ���#1E2A38 �� Orientation$ Vertical=�6*   .+�5      �� -   5        $��Đăng nhập��5      
 � Tag$ 	LoginView��6)   
������ 
�������
������ $��40��5   [   �� 5      -   5        $��
Đăng ký��5      $ RegisterView��6'   
������ 
�������
������ $��40��5   [   �� 5      -   5        $��Đăng xuất��5      $ 
LogoutView��6)   
������ 
�������
������ $��40��5   [   �� 5      -   5        $��Kiểm thử hàng loạt��5      $ 	BatchView��62   
������ 
�������
������ $��40��5   [   5      �� 5   
   -   5         ��Name$ MainContent��5      $��1��6.   $��10q�6>   5      5      