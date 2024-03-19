using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsAppMaster.Models;

namespace WinFormsAppMaster.Interfaces
{
    public interface IDatabase<T>
    {
        // 테이블에서 전체 데이터 조회
        List<T> Get();

        // 테이블에서 특정 데이터 조회
        T GetDetail(int? id);

        // 테이블에 새로운 행 삽입
        void Create(T entity);

        // 테이블에 기존 행 업데이트
        void Update(T entity);

        // 테이블에 기존 행 삭제
        void Delete(int? id);
    }
}
