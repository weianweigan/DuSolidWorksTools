# DuSolidWorksEx

## 一.介绍
* 基于Visual Stdio的扩展用来增强对SolidWoks二次开发的体验。

## 二.功能

### 2.1 SolidWorks信息,插件管理,选择枚举信息

#### 2.1.1 查看本机SolidWorks信息

* 启动按钮直接启动SolidWorks
* 打开SolidWorks安装目录
* 安装SolidWorks.Interop.* 依赖
![SolidWorks](.\picture\swinfo.png)

#### 2.1.2 插件管理

* 查看当前电脑安装的插件信息
* 不启动SolidWorks安装卸载插件
* 注册dll插件
![Addin](.\picture\addininfo.png)

#### 2.1.3 查看选择对象的枚举信息(查看其它信息开发中)

* 查看选择对象的枚举类型
* 选择对象其他信息开发中
![](.\picture\selectedinfo.png)

### 2.2 安装SolidWorks插件依赖的 SolidWorks.Interop.* 

* 安装开发SolidWorks 插件的依赖信息.
* 可选择是否复制到解决方案工作目录
* 如果电脑安装多版本SolidWorks 可选择不同版本
![](.\picture\reference.png)

### 2.3 VisualStudio QucikInfo 和 SignatureInfo

快速查看SolidWorks Api 的信息 和 方法信息

* 属性信息
![](.\picture\propertyinfo.png)

* 方法信息
![](.\picture\swmethodinfo.png)

* 枚举信息 
![](.\picture\enuminfo.png)

* 事件信息
![](.\picture\eventinfo.png)

* 接口信息
![](.\picture\interfaceinfo.png)

* 签名信息,但不知道为什么没有着色,希望有人解答
![](.\picture\signinfo.png)

### 2.4 查看帮助信息 SolidWorks Api Help

* 右击在本地查看帮助  
![](.\picture\apihelp.png)

* 在VisualStudio中查看网页帮助(加载慢)
![](.\picture\vsapihelp.png)

* 在外部浏览器中查看帮助
![](.\picture\browserapihelp.png)


### 2.5 项目模板

* 安装此插件可以自动安装SolidWorks C# Addin 模板
![](.\picture\template.png)

#### 安装

* 仅支持Viusal Studio 2019

* 在Visual Studio 扩展商店搜索DuSolidWorksTools 或 release 中下载安装包

#### 包管理

1. MVVM.Light-wpf的mvvm
2. Xceed.toolkit.wpf-使用property grid
3. anglesharp-解析solidworks的html数据
4. mircosfot.codeanalysis.lauguageservices-解析语法

