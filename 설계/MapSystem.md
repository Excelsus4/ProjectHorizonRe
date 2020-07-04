#Map System
이 새로운 맵 시스템은 기존 게임들의 맵 에디터의 형식에 착안하여 여러 종류의 조건과 행동을 조립해서 만들 수 있는 트리거들을 이용해 맵에 생명을 불어넣을 수 있도록 되어있다.

##ConditionComponent
Awake()- 시나리오 시작하자 마자 1회 발동
Eliminate(string CertainName, int N)- 특정 이름의 몬스터를 N마리 처치 시 1회 발동
Reach(rect CertainRange)- 특정 범위에 플레이어가 진입 시 1회 발동

##ActionComponent
PlayerTeleport(Vector2 CertainPosition)- 플레이어 캐릭터를 특정 위치로 순간이동
CreateObject (Vector2 CertainPosition, GameObject CertainObject)- 특정 위치에 지정된 오브젝트를 생성
Victory()- 시나리오를 승리로 종료

