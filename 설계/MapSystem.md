ConditionComponent
AWAKE()- 시나리오 시작하자 마자 발동
ELIMINATE(string 특정이름, int N)- 특정 이름의 몬스터를 N마리 처치 시 발동
REACH(rect 특정범위)- 특정 범위에 플레이어가 진입 시 1회 발동

ActionComponent
PlayerTeleport(Vector2 CertainPosition)- 플레이어 캐릭터를 특정 위치로 순간이동
CreateObject (Vector2 CertainPosition, GameObject CertainObject)- 특정 위치에 지정된 오브젝트를 생성
VICTORY- 시나리오를 승리로 종료

