import requests

# Настройки
api_token = 'y0_AgAAAABdx8V8AAr6sgAAAAD0lRNoGTu4N5UlS82mwTRCNB7t4tHHwLE'  # Замените на ваш токен
queue_id = 'TEAMCITYBUILDFA'    # ID созданной очереди
owner_id = 'aje5onvp7suh6hbr1jhh'    # ID владельца очереди

# URL для создания задачи
url = 'https://tracker.yandex.ru/createTicket?queue=TEAMCITYBUILDFA&_form=false'

headers = {
    'Authorization': f'OAuth {api_token}',
    'X-Org-ID': 'bpfbmihbfa98v3kflolj'  # ID вашей организации в Yandex Tracker
}

# Данные для создания задачи
data = {
    'queue': queue_id,
    'summary': 'Build Failure in TeamCity',
    'description': 'A build has failed in TeamCity. Please investigate.',
    'assignee': owner_id
}

# Отправка запроса на создание задачи
response = requests.post(url, headers=headers, json=data)

if response.status_code == 201:
    print('Task created successfully')
else:
    print('Failed to create task')