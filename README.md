# BCI Helirun Project
연세대학교 생활디자인학과 디지털미디어연구실에서는 한국연구재단 과학문화전시서비스 역량강화지원사업(NRF-2018X1A3A1070352)에서 지원을 받아 ‘뇌과학 가치확산을 위한 과학문화 전시 VR/AR 콘텐츠 개발’ 프로젝트를 진행하고 있으며,  본 프로젝트에서 개발한 콘텐츠 '헬리런'에 관련된 코드 설명입니다.

전반적인 설치 가이드라인에 대해선 아래의 링크를 참조하세요. 
https://docs.google.com/document/d/1uWdjW5s1uQayeMgwd3Y5VtT6Q42U3DMjzesE2Jti14Y/edit#

전체 유니티 프로젝트는 아래의 링크를 참조하세요.
https://drive.google.com/drive/folders/1kH4A9p2Ql3PIxMibrg8pIeuNDG39J9uf?usp=sharing

게임의 최종 버전은 아래의 링크를 참조하세요 (윈도우 버전, .exe 파일) 
https://drive.google.com/file/d/1RnjrvHE05DU5xG2w4jgB0-hkp3yAqXx8/view?usp=sharing

코드는 5개의 구분으로 나뉘어져 있으나, 실제 Unity 내 구분이 아니라 사용자의 편의를 위한 구분입니다. 각 구분별로 코드별 상세 설명을 참조 후 사용 바랍니다. 

## 1. Asset
### Asset Spreader
사용자 지정 asset 을 지정된 범위내에서 렌덤으로 배치합니다. Circle 은 원형으로, 일반은 직사각형 모양으로 구성되며, 게임 플레이 당시에만 보여집니다. CPU를 많이 사용하니 주의해야 합니다. 
### Floater
사용자 지정 asset 을 둥둥 띄운것처럼 움직이게 합니다. 움직임의 높이를 지정할 수 있으며, 움직임의 속도 또한 지정할 수 있습니다. 
### Image Swap 
다양한 image sprite 들이 조건에 따라 변경될 수 있게 해줍니다. 위 코드의 경우 OSC 데이터에 따라 변경되게 하였습니다. 

## 2. Control
### Fade Out
게임 플레이 끝에 자연스럽게 검은 화면으로 연결될 수 있게 하는 코드 입니다. 
### Follow Camera
카메라가 사용자 지정 asset 을 지정 간격과 지정 각도 내에서 자연스럽게 따라갈 수 있게 하는 코드입니다. 
### OSC Receiver 
OSC 데이터를 받는 코드입니다. 개발 과정에선 BCI 데이터를 받는데에 사용하였습니다. CPU 사용량이 많으니 사용시 주의해야합니다. 
### Play Control
게임을 플레이 했을때 특정 부분을 스킵하고 진행 할 수 있게 하는 코드입니다. 개발 당시에만 사용하고 최종 compile 당시엔 제거해야 합니다. 
### Simple Camera Controller 
카메라를 사용자 지정 asset 에서 부터 특정 거리 뒤에서 따라갈 수 있게 하는 코드입니다. 
### Start Menu
처음 시작 메뉴를 생성하는 코드입니다. 메뉴에서 선택하는 캐릭터만 게임 상에서 나타날 수 있게 구성됩니다. 
### Window Graph 
각 캐릭터 밑에서 뇌파의 변화를 보여주는 그래프를 생성하는 코드입니다. 

## 3. Depress
### Depress 
우울이가 파티클을 맞으면 사라지는 코드입니다. 같은 코드를 다른 asset 이 가지고 있는 경우 한개의 global variable 로 취급되어 우울이 별로 각각 다른 이름의 코드가 필요합니다. 

## 4. Helirun
### Helirun Move 
헬리런이 위아래로 움직이게 하는 코드입니다. 뇌파 데이터에 따라 다르게 움직이며, 뇌파의 상위 하위 제한점은 지정 가능합니다. 현재 4 cm 로 설정되어 있습니다.   

## 5.Particle
### Send Particle
헬리런으로 부터 나오는 알파파 및 베타파를 조정하는 코드입니다. 파티클의 사이즈와 나오는 개수를 조절합니다.
### Shoot Particle
우울이들을 처치하는 파티클들을 일정 범위 이상의 뇌파가 나왔을때 발사하는 코드입니다. 

## 기타 문의 사항 
문제가 있을 시 ysdesigntech@gmail.com 으로 연락 바랍니다.
