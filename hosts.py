def cleanhosts(name):
    with open('C:/Windows/System32/drivers/etc/hosts', 'r', encoding='utf-8') as f:
        lines = f.readlines()
    ge = [name, 'Beyond']
    new = ''
    for line in lines:
        mode = True
        for i in ge:
            if i in line:
                mode = False
                break
        if mode:
            new += line
    with open('C:/Windows/System32/drivers/etc/hosts', 'w', encoding='utf-8') as f:
        f.write(new)


if __name__ == '__main__':
    cleanhosts('#discord')
    cleanhosts('#github')
    cleanhosts('#v2ex')
    cleanhosts('#nyaa')
    cleanhosts('#pixiv')
    cleanhosts('#duckduckgo')
    cleanhosts('#ms')
    cleanhosts('#exhentai')
    cleanhosts('#steam')
